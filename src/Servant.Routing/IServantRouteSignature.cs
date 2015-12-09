namespace Servant.Routing
{
    /// <summary>
    /// Defines an interface that represents a signature for a route, which is a way of identifying requests that can be handled by the route.
    /// </summary>
    public interface IServantRouteSignature
    {
        /// <summary>
        /// Gets the array of path segments that make up the signature.
        /// </summary>
        IServantRoutePathSegment[] Paths { get; }
    }
}