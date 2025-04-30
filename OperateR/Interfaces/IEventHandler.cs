namespace OperateR.Interfaces
{
    /// <summary>
    /// Defines a handler for a specific type of event that produces a response.
    /// Used to process events that implement <see cref="IEvent{TResponse}"/> and return a result.
    /// </summary>
    /// <typeparam name="TEvent">The type of the event to handle. Must implement <see cref="IEvent{TResponse}"/>.</typeparam>
    /// <typeparam name="TResponse">The type of response produced by handling the event.</typeparam>
    public interface IEventHandler<in TEvent, TResponse> where TEvent : IEvent<TResponse>
    {
        /// <summary>
        /// Handles the specified event and returns a response asynchronously.
        /// </summary>
        /// <param name="@event">The event instance to handle.</param>
        /// <param name="cancellationToken">A token to observe for cancellation requests.</param>
        /// <returns>A task representing the asynchronous handling operation, containing the result.</returns>
        Task<TResponse> Handle(TEvent @event, CancellationToken cancellationToken);
    }

}
