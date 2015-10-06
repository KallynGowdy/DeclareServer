using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servant.Test.Routing.Unit
{
    /// <summary>
    /// Test writing routes using the core routing library.
    /// </summary>
    public class TestConfigureCoreRoutes
    {
        public class TestController
        {
            
        }

        public TestConfigureCoreRoutes()
        {
            //RouteBuilder = routeBuilder;
        }

        IServantRouteBuilder RouteBuilder { get; }

        [Fact]
        public void Test_Simple_Static_Get_Route_Can_Be_Made()
        {
            RouteBuilder.Get("static-page").To<TestController>();
        }

    }
}
