using System;
using Microsoft.Framework.DependencyInjection;

namespace Servant
{
    public static class ServantServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the dependencies for Servant to the given <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The collection of services that Servant should be added to.</param>
        /// <returns>Returns the given <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddServant(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            // TODO: Add Dependencies
            return services;
        }
    }
}
