namespace OperateR.Interfaces
{
    /// <summary>
    /// Defines a pipeline behavior that can be used to intercept and handle logic before and/or after a request is processed by its handler.
    /// Common use cases include logging, validation, performance monitoring, and exception handling.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request being handled.</typeparam>
    /// <typeparam name="TResponse">The type of the response returned by the request handler.</typeparam>
    public interface IPipelineBehavior<TRequest, TResponse>
    {
        /// <summary>
        /// Handles the pipeline behavior for the specified request.
        /// This method can run custom logic before or after calling the next delegate in the pipeline.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <param name="next">A delegate that represents the next step in the pipeline (usually the handler).</param>
        /// <param name="cancellationToken">A token to observe for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation and returns the response.</returns>
        Task<TResponse> Handle(TRequest request, Func<Task<TResponse>> next, CancellationToken cancellationToken = default);
    }
}
