namespace Servant.Routing
{
    /// <summary>
    /// Defines an interface that represents a request for an operation to be performed.
    /// </summary>
    public interface IServantRequest
    {
        /// <summary>
        /// Gets the contents that have been retrieved for the request.
        /// </summary>
        IServantContent[] Contents { get; }
    }
}