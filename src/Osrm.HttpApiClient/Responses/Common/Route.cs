using System;
using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Represents a route through (potentially multiple) waypoints.
    /// </summary>
    /// <typeparam name="TGeometry"></typeparam>
    public record Route<TGeometry>
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
        /// The whole geometry of the route value depending on overview parameter, format depending on the geometries parameter.
        /// See RouteStep's geometry property for a parameter documentation.
        /// <seealso cref="RouteStep.Geometry"/>
        /// </summary>
        [JsonPropertyName("geometry")]
        public TGeometry? Geometry { get; set; }

        /// <summary>
        /// The calculated weight of the route.
        /// </summary>
        [JsonPropertyName("weight")]
        public float Weight { get; set; }

        /// <summary>
        /// The name of the weight profile used during extraction phase.
        /// </summary>
        [JsonPropertyName("weight_name")]
        public string WeightName { get; set; } = null!;

        /// <summary>
        /// The legs between the given waypoints, an array of RouteLeg objects.
        /// </summary>
        [JsonPropertyName("legs")]
        public RouteLeg<TGeometry>[] Legs { get; set; } = Array.Empty<RouteLeg<TGeometry>>();
    }
}
