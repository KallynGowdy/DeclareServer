namespace Servant.Routing
{
    /// <summary>
    /// Defines an interface that represents a piece of content that was retrieved for a route.
    /// </summary>
    public interface IServantContent
    {
        /// <summary>
        /// Gets whether the content is available or whether it was not retrieved.
        /// </summary>
        bool IsAvailable { get; }
    }
}