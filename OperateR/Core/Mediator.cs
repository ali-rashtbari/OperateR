using Microsoft.Extensions.DependencyInjection;
using OperateR.Interfaces;

namespace OperateR.Core
{
    /// <summary>
    /// Implements the <see cref="IMediator"/> interface, providing functionality for sending requests and publishing notifications.
    /// The mediator handles processing a request through its corresponding handler, as well as executing any pipeline behaviors that are registered.
    /// </summary>
    public class Mediator(IServiceProvider serviceProvider) : IMediator
    {
        /// <inheritdoc/>
        public async Task<TResponse> Send<TResponse>(IOperation<TResponse> request, CancellationToken cancellationToken = default)
        {
            // Resolve handler and behaviors for the request
            var handlerType = typeof(IHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            var handler = serviceProvider.GetService(handlerType) ?? throw new InvalidOperationException($"No handler found for {request.GetType().Name}");

            var behaviorType = typeof(IPipelineBehavior<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            var behaviors = serviceProvider.GetServices(behaviorType).Cast<object>().Reverse();

            // Create the initial delegate to handle the request
            Func<Task<TResponse>> handlerDelegate = async () =>
            {
                var method = handlerType.GetMethod("Handle") ?? throw new InvalidOperationException("Handle method not found.");
                return await (Task<TResponse>)method.Invoke(handler, [request, cancellationToken])!;
            };

            // Apply all behaviors in reverse order
            foreach (var behavior in behaviors)
            {
                var next = handlerDelegate;
                handlerDelegate = async () =>
                {
                    var method = behavior.GetType().GetMethod("Handle") ?? throw new InvalidOperationException("Handle method not found.");
                    return await (Task<TResponse>)method.Invoke(behavior, [request, next, cancellationToken])!;
                };
            }

            // Execute the final handler after applying all behaviors
            return await handlerDelegate();
        }

        /// <inheritdoc/>
        public async Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            // Resolve all notification handlers for the notification type
            var handlerType = typeof(INotificationHandler<>).MakeGenericType(notification.GetType());
            var handlers = serviceProvider.GetServices(handlerType).ToArray();

            if (handlers.Length == 0)
            {
                throw new InvalidOperationException($"No handlers found for {typeof(TNotification).Name}");
            }

            // Execute all handler tasks concurrently
            var tasks = handlers.Select(handler =>
            {
                var method = handlerType.GetMethod("Handle") ?? throw new InvalidOperationException("Handle method not found.");
                return (Task)method.Invoke(handler, [notification, cancellationToken])!;
            });

            await Task.WhenAll(tasks);
        }
    }
}