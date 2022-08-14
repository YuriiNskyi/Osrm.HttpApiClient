using System;
using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Represents a route between two waypoints.
    /// </summary>
    public record RouteLeg<TGeometry>
        where TGeometry : Geometry
    {
        /// <summary>
        /// The distance traveled by the route, in float meters.
        /// </summary>
        [JsonPropertyName("distance")]
        public float Distance { get; set; }

        /// <summary>
        /// The estimated travel time, in float number of seconds.
        /// </summary>
        [JsonPropertyName("duration")]
        public float Duration { get; set; }

        /// <summary>
        /// The calculated weight of the route.
        /// </summary>
        [JsonPropertyName("weight")]
        public float Weight { get; set; }

        /// <summary>
        /// Summary of the route taken as string. Depends on the summary parameter:
        /// Names of the two major roads used. Can be empty if route is too short. Or empty string.
        /// </summary>
        [JsonPropertyName("summary")]
        public string Summary { get; set; } = null!;

        /// <summary>
        /// Array of RouteStep objects describing the turn-by-turn instructions.
        /// </summary>
        [JsonPropertyName("steps")]
        public RouteStep<TGeometry>[] Steps { get; set; } = Array.Empty<RouteStep<TGeometry>>();

        /// <summary>
        /// Additional details about each coordinate along the route geometry:
        /// </summary>
        [JsonPropertyName("annotations")]
        public RouteLegAnnotation Annotations { get; set; } = null!;
    }
}
