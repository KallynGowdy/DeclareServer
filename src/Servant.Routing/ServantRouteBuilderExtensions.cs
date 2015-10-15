using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servant.Routing
{
    /// <summary>
    /// Defines a class that contains extensions for <see cref="IServantRouteBuilder{TMessage}"/> objects.
    /// </summary>
    public static class ServantRouteBuilderExtensions
    {
        private class AnonymousService
        {
        }

        public static void To<TMessage, TReturn>(this IServantRouteBuilder<TMessage> builder, Func<TMessage, TReturn> service)
        {
            builder.To<AnonymousService>().Handler((s, m) => service(m));
        }
    }
}
