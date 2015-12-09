using System;

namespace Servant.Routing
{
    /// <summary>
    /// Defines an interface that represents a segment of a URL path for a <see cref="IServantRouteSignature"/>.
    /// </summary>
    public interface IServantRoutePathSegment
    {
        /// <summary>
        /// Gets the type of values that this segment represents.
        /// </summary>
        Type SegmentType { get; }

        /// <summary>
        /// Parses the given value into a usable value.
        /// </summary>
        /// <param name="value">The string that should be parsed.</param>
        /// <returns></returns>
        ParseResult ParseValue(string value);
    }

    /// <summary>
    /// Defines an interface that represents a segment of a URL path for a <see cref="IServantRouteSignature"/>.
    /// </summary>
    public interface IServantRoutePathSegment<T>
    {
        /// <summary>
        /// Parses the given value into a usable value.
        /// </summary>
        /// <param name="value">The string that should be parsed.</param>
        /// <returns></returns>
        ParseResult<T> ParseValue(string value);
    }
}