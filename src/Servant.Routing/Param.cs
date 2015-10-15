using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servant.Routing
{
    /// <summary>
    /// Defines a class that represents a query parameter in a URL configuration.
    /// </summary>
    public abstract class Param
    {

        public static string operator /(string left, Param right)
        {
            return null;
        }

        public static string operator /(Param left, Param right)
        {
            return null;
        }

    }

    public class Param<T> : Param
    {
        
    }
}
