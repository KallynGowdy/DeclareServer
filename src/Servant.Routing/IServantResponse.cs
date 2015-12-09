namespace Servant.Routing
{
    /// <summary>
    /// Defines an interface that represents a response to a request.
    /// </summary>
    public interface IServantResponse
    {
        /// <summary>
        /// Gets wether the operation was able to be performed.
        /// </summary>
        bool IsSuccess { get; }
    }
}