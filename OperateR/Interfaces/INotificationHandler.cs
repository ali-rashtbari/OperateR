namespace OperateR.Interfaces
{
    /// <summary>
    /// Defines a handler for a specific type of notification.
    /// Notifications represent fire-and-forget messages that can be processed by zero or more handlers.
    /// </summary>
    /// <typeparam name="TNotification">The type of the notification to handle. Must implement <see cref="INotification"/>.</typeparam>
    public interface INotificationHandler<in TNotification> where TNotification : INotification
    {
        /// <summary>
        /// Handles the specified notification asynchronously.
        /// </summary>
        /// <param name="notification">The notification instance to handle.</param>
        /// <param name="cancellationToken">A token to observe for cancellation requests.</param>
        /// <returns>A task representing the asynchronous handling operation.</returns>
        Task Handle(TNotification notification, CancellationToken cancellationToken);
    }

}
