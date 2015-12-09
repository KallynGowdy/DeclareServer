using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Servant.Routing;
using Xunit;

namespace Servant.Test.Routing.Unit
{
    /// <summary>
    /// Tests for <see cref="StaticRoutePathSegment"/>.
    /// </summary>
    public class TestStaticRoutePathSegment
    {
        StaticRoutePathSegment segment = new StaticRoutePathSegment("static-path");

        [Theory]
        [InlineData("static-path", true)]
        [InlineData("Static-path", true)]
        [InlineData("staticpath", false)]
        public void Test_Parse_String_Value(string value, bool valid)
        {
            var result = segment.ParseValue(value);
            Assert.Equal(result.IsSuccessful, valid);
        }

    }
}
