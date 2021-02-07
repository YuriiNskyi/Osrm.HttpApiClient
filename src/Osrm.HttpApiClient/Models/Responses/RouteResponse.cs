using System;
using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    public record RouteResponse<TGeometry> : CommonResponse
        where TGeometry : Geometry
    {
        /// <summary>
        /// Array of Waypoint objects sorted by distance to the input coordinate.
        /// </summary>
        [JsonPropertyName("waypoints")]
        public Waypoint[] Waypoints { get; set; } = Array.Empty<Waypoint>();

        /// <summary>
        /// An array of Route objects, ordered by descending recommendation rank.
        /// </summary>
        [JsonPropertyName("routes")]
        public Route<TGeometry>[] Routes { get; set; } = Array.Empty<Route<TGeometry>>();
    }
}
