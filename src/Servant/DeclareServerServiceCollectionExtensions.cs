using System;
using Microsoft.Framework.DependencyInjection;

namespace Servant
{
    public static class DeclareServerServiceCollectionExtensions
    {
        public static void AddDeclareServer(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
        }

        public static void AddDeclareServer(this IServiceCollection services, Action setupAction)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Add Default Servant Services to DI 

            if (setupAction != null)
            {
                
            }
        }
    }
}
