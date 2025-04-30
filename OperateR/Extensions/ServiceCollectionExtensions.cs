using Microsoft.Extensions.DependencyInjection;
using OperateR.Core;
using OperateR.Interfaces;
using System.Reflection;

namespace OperateR.Extensions
{
    /// <summary>
    /// Provides extension methods for registering OperateR mediator-related services in the dependency injection container.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the OperateR mediator, request handlers, and notification handlers found in the specified assemblies.
        /// </summary>
        /// <param name="services">The service collection to which the registrations will be added.</param>
        /// <param name="assemblies">The assemblies to scan for handler implementations.</param>
        /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
        public static IServiceCollection AddOperateR(this IServiceCollection services, params Assembly[] assemblies)
        {
            // Register the core Mediator implementation
            services.AddScoped<Mediator>();

            // Register a factory to resolve types dynamically
            services.AddScoped<Func<Type, object>>(sp => type => sp.GetService(type)!);

            // Register all IHandler<,> and INotificationHandler<> implementations found in the given assemblies
            foreach (var assembly in assemblies)
            {
                var handlerTypes = assembly
                    .GetTypes()
                    .Where(t => !t.IsAbstract && !t.IsInterface)
                    .SelectMany(t => t.GetInterfaces(), (t, i) => new { Implementation = t, Interface = i })
                    .Where(x => x.Interface.IsGenericType && (x.Interface.GetGenericTypeDefinition() == typeof(IHandler<,>) || x.Interface.GetGenericTypeDefinition() == typeof(INotificationHandler<>)));

                foreach (var h in handlerTypes)
                {
                    services.AddScoped(h.Interface, h.Implementation);
                }
            }

            return services;
        }
    }
}
