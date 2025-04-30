namespace OperateR.Interfaces
{
    /// <summary>
    /// Represents an operation or request that expects a response of type <typeparamref name="TResponse"/>.
    /// This is the base interface for commands or queries handled by the mediator.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response expected after the operation is processed.</typeparam>
    public interface IOperation<TResponse> { };
}