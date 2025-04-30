namespace OperateR.Interfaces
{
    public interface IHandler<in TRequest, TResponse> where TRequest : IOperation<TResponse>
    {
        /// <summary>
        /// Handles the specified request and returns a response asynchronously.
        /// </summary>
        /// <param name="request">The operation to handle.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation, containing the response.</returns>
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}