using System;
using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Object used to describe waypoint on a route.
    /// </summary>
    public record Waypoint
    {
        /// <summary>
        /// Array of OpenStreetMap node ids.
        /// </summary>
        [JsonPropertyName("nodes")]
        public long[] Nodes { get; set; } = Array.Empty<long>();

        /// <summary>
        /// Name of the street the coordinate snapped to.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Array that contains the [longitude, latitude] pair of the snapped coordinate.
        /// </summary>
        [JsonPropertyName("location")]
        public double[] Location { get; set; } = Array.Empty<double>();

        /// <summary>
        /// The distance, in metres, from the input coordinate to the snapped coordinate.
        /// </summary>
        [JsonPropertyName("distance")]
        public float Distance { get; set; }

        /// <summary>
        /// Unique internal identifier of the segment (ephemeral, not constant over data updates).
        /// This can be used on subsequent request to significantly speed up the query and to connect multiple services.
        /// E.g. you can use the hint value obtained by the nearest query as hint values for route inputs.
        /// </summary>
        [JsonPropertyName("hint")]
        public string Hint { get; set; } = null!;
    }
}