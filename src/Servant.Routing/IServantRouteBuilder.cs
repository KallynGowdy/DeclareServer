using System;

namespace Servant.Routing
{
    /// <summary>
    /// Defines an interface for an object that allows configuration of a single route.
    /// </summary>
    /// <typeparam name="TMessage">The type that represents the message that will be routed.</typeparam>
    public interface IServantRouteBuilder<TMessage>
    {
        IServantRouteServiceBuilder<TMessage, TService> To<TService>();
    }

    public interface IServantRouteServiceBuilder<TMessage, TService>
    {
        void Handler<TReturn>(Func<TService, TMessage, TReturn> handler);
    }
}