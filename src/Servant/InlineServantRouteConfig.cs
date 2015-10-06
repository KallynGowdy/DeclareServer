using System;
using Servant.Core;

namespace Servant
{
    /// <summary>
    /// Defines a class that allows routes to be configured via an inline action over a custom class.
    /// </summary>
    public class InlineServantRouteConfig : IServantRouteConfig
    {
        private readonly Action<IServantRouteBuilder> setupAction;

        public InlineServantRouteConfig(Action<IServantRouteBuilder> setupAction)
        {
            if (setupAction == null) throw new ArgumentNullException(nameof(setupAction));
            this.setupAction = setupAction;
        }

        public void Register(IServantRouteBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            setupAction(builder);
        }
    }
}