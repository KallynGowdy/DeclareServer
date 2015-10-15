using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servant.Routing
{
    /// <summary>
    /// Defines a class that contains extensions for <see cref="IServantRouteCollection"/> objects.
    /// </summary>
    public static class ServantRouteCollectionExtensions
    {
        /// <summary>
        /// Adds a route that responds to a GET request at the given url.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="url">The URL that the page will be accessed at.</param>
        /// <returns>Returns a new <see cref="IServantRouteBuilder{TMessage}"/> object that can be used to configure the route.</returns>
        public static IServantRouteBuilder<dynamic> Get(this IServantRouteCollection collection, string url)
        {
            return collection.Get<dynamic>(url);
        }
    }
}
