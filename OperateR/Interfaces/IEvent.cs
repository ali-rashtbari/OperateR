namespace OperateR.Interfaces
{
    /// <summary>
    /// Represents an event that can be published through the mediator and returns a result upon handling.
    /// Inherits from <see cref="INotification"/> to be used as a publishable event, but also includes a <c>Handle</c> method for execution logic.
    /// </summary>
    /// <typeparam name="TResponse">The type of response the event handler returns.</typeparam>
    public interface IEvent<TResponse> : INotification
    {
        /// <summary>
        /// Executes the event's handling logic and returns a response asynchronously.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous handling operation, containing the response.</returns>
        Task<TResponse> Handle(CancellationToken cancellationToken);
    }

}
