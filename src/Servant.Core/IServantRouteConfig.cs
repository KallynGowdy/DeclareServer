namespace Servant.Core
{
    /// <summary>
    /// Defines an interface that represents a routing configuration for Servant.
    /// </summary>
    public interface IServantRouteConfig
    {

        /// <summary>
        /// Registers the routes with the given builder.
        /// </summary>
        /// <param name="builder">The <see cref="IServantRouteBuilder"/> that can be used to define custom routes.</param>
        void Register(IServantRouteBuilder builder);

    }
}