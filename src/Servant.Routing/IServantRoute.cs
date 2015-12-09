using System;

namespace Servant.Routing
{
    /// <summary>
    /// Defines an interface that represents a route that is able to handle requests.
    /// </summary>
    public interface IServantRoute
    {
        /// <summary>
        /// Handles the given request and returns a response that represents the result.
        /// </summary>
        /// <param name="request">The request that should be handled.</param>
        /// <returns>Returns a response which is the message to return.</returns>
        IServantResponse HandleRequest(IServantRequest request);

        /// <summary>
        /// Gets the "signature" of the route, which is a value that determines whether the route is able to handle a given request.
        /// </summary>
        IServantRouteSignature Signature { get; }
    }

    /// <summary>
    /// Defines an interface that represents a route that is handled by an object of type <typeparamref name="TRouteHandler"/> and returns a response of
    /// type <typeparamref name="TResponse"/>.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response that is returned to the client.</typeparam>
    /// <typeparam name="TRequest">The type of objects that are bound to the request.</typeparam>
    public interface IServantRoute<in TRequest, out TResponse> : IServantRoute
        where TRequest : IServantRequest
        where TResponse : IServantResponse
    {
        /// <summary>
        /// Handles the given request and returns a response that represents the result.
        /// </summary>
        /// <param name="request">The request that should be handled.</param>
        /// <returns>Returns a response which is the message to return.</returns>
        TResponse HandleRequest(TRequest request);
    }
}