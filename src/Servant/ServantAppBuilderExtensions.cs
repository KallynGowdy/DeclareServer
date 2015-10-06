using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Servant.Core;

namespace Servant
{
    public static class ServantAppBuilderExtensions
    {
        /// <summary>
        /// Registers the Servant middleware in the application.
        /// </summary>
        /// <typeparam name="TRouteConfig"></typeparam>
        /// <param name="app"></param>
        public static void UseServant<TRouteConfig>(this IApplicationBuilder app)
            where TRouteConfig : IServantRouteConfig, new()
        {

        }

        /// <summary>
        /// Registers the Servant middleware in the application.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configAction"></param>
        public static void UseServant(this IApplicationBuilder app, Action<IServantRouteBuilder> configAction)
        {
            
        }
    }
}
