using System;

namespace Servant.Routing
{
    public class StaticRoutePathSegment : IServantRoutePathSegment<string>
    {
        public string Segment { get; }

        public StaticRoutePathSegment(string segment)
        {
            Segment = segment;
        }

        public ParseResult<string> ParseValue(string value)
        {
            return string.Equals(Segment, value, StringComparison.OrdinalIgnoreCase)
                ? ParseResult<string>.Success(Segment)
                : ParseResult<string>.Failed();
        }
    }
}