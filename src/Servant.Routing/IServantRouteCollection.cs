using System;
using System.Linq.Expressions;

namespace Servant.Routing
{
    /// <summary>
    /// Defines an interface that allows configuration of routes.
    /// </summary>
    public interface IServantRouteCollection
    {
        /// <summary>
        /// Adds a route that responds to a GET request at the given url.
        /// </summary>
        /// <typeparam name="TMessage">The type of the message that will be sent to the service.</typeparam>
        /// <param name="url">The URL that the page will be accessed at.</param>
        /// <returns>Returns a new <see cref="IServantRouteBuilder{TMessage}"/> object that can be used to configure the route.</returns>
        IServantRouteBuilder<TMessage> Get<TMessage>(string url);

        IServantRouteBuilder<TMessage> Get<TMessage>(Expression<Func<TMessage, string>> url);

        IServantRouteBuilder<TMessage> GetBinder<TMessage>(Func<IServantMessageBindingBuilder<TMessage>, IServantMessageBindingBuilder<TMessage>> setup);
    }

    public interface IServantMessageBindingBuilder<T>
    {
    }
}