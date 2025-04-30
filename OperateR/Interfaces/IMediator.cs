namespace OperateR.Interfaces
{
    /// <summary>
    /// Represents a mediator responsible for sending operations and publishing notifications.
    /// Provides methods to decouple request handling and event distribution.
    /// </summary>
    public interface IMediator
    {
        /// <summary>
        /// Sends a request operation to its corresponding handler and returns the result.
        /// </summary>
        /// <typeparam name="TResponse">The type of response expected from the operation.</typeparam>
        /// <param name="request">The operation to process.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous send operation, containing the result.</returns>
        Task<TResponse> Send<TResponse>(IOperation<TResponse> request, CancellationToken cancellationToken = default);

        /// <summary>
        /// Publishes a notification event to all its registered handlers.
        /// </summary>
        /// <typeparam name="TNotification">The type of the notification to publish.</typeparam>
        /// <param name="notification">The notification to broadcast to its handlers.</param>
        /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous publish operation.</returns>
        Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification;
    }
}