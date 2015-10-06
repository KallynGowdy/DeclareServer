using System;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;

namespace Servant.Core
{
    /// <summary>
    /// Defines an interface for an object that allows custom routes to be defined.
    /// </summary>
    public interface IServantRouteBuilder
    {
        /// <summary>
        /// Defines a route that responds to GET requests for the given URL.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        IServantRouteDefinitionBuilder<TRequestMessage> Get<TRequestMessage>(Expression<Func<TRequestMessage, string>> urlDef)
            where TRequestMessage : ServantRoute;

        IServantRouteDefinitionBuilder<TRequestMessage> Post<TRequestMessage, TRequestBody>(Expression<Func<TRequestMessage, string>> urlDef, Func<TRequestMessage, TRequestBody, object> modelDef)
            where TRequestMessage : ServantRoute;

        IServantRouteDefinitionBuilder<TRequestMessage> Put<TRequestMessage, TRequestBody>(Func<TRequestMessage, string> urlDef, Func<TRequestMessage, TRequestBody, object> modelDef);
        IServantRouteDefinitionBuilder<TRequestMessage> Delete<TRequestMessage>(Func<TRequestMessage, string> urlDef);
    }

    public abstract class ServantRoute
    {
    }

    public class RouteParam<TProp>
    {
        public static string operator /(RouteParam<TProp> m, string s)
        {
            return "";
        }

        public static string operator /(string s, RouteParam<TProp> m)
        {
            return "";
        }

        public static string operator /(RouteParam<TProp> s, RouteParam<TProp> m)
        {
            return "";
        }

        public static implicit operator string (RouteParam<TProp> s)
        {
            return "";
        }

        public static RouteParam<TProp> operator ++(RouteParam<TProp> p)
        {
            return p;
        }
    }

    public abstract class ServantRoute<TReturn> : ServantRoute
    {
        protected HttpWebRequest Request { get; }

        public static string operator /(ServantRoute<TReturn> m, string s)
        {
            return "";
        }

        public static string operator /(string s, ServantRoute<TReturn> m)
        {
            return "";
        }

        public static string operator /(ServantRoute<TReturn> s, ServantRoute<TReturn> m)
        {
            return "";
        }

        public static implicit operator string(ServantRoute<TReturn> s)
        {
            return "";
        }
        
        public abstract Task<TReturn> HandleAsync();
    }

    public sealed class ServantRouteProp
    {
        private ServantRouteProp()
        {
        }
    }

    public sealed class ServantRouteProp<TProp>
    {
        private ServantRouteProp()
        {
        }

        public static string operator /(ServantRouteProp<TProp> m, string s)
        {
            return "";
        }

        public static string operator /(string s, ServantRouteProp<TProp> m)
        {
            return "";
        }
    }

    /// <summary>
    /// Defines an interface for objects that allow a custom route to be defined.
    /// </summary>
    /// <typeparam name="TQuery"></typeparam>
    public interface IServantRouteDefinitionBuilder<TQuery>
    {
        IServantRouteDefinitionBuilder<TQuery, TController> ToController<TController>();
        IServantRouteBuilder Route(Action<IServantRouteBuilder> action);
    }

    public interface IServantRouteDefinitionBuilder<TQuery, TController>
    {
        void ToMethod<TReturn>(Expression<Func<TQuery, TController, TReturn>> methodSelector);
    }
}