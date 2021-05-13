using System;
using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    public record TableResponse : CommonResponse
    {
        /// <summary>
        /// Array of arrays that stores the matrix in row-major order.
        /// Durations[i][j] gives the travel time from the i-th waypoint to the j-th waypoint.
        /// Values are given in seconds.
        /// Can be null, if no route between i and j can be found.
        /// </summary>
        [JsonPropertyName("durations")]
        public float?[][] Durations { get; set; } = Array.Empty<float?[]>();

        /// <summary>
        /// Array of arrays that stores the matrix in row-major order.
        /// Distances[i][j] gives the travel distance from the i-th waypoint to the j-th waypoint.
        /// Values are given in meters.
        /// Can be null, if no route between i and j can be found.
        /// </summary>
        [JsonPropertyName("distances")]
        public float?[][] Distances { get; set; } = Array.Empty<float?[]>();

        /// <summary>
        /// Array of Waypoint objects describing all sources in order.
        /// </summary>
        [JsonPropertyName("sources")]
        public Waypoint[] Sources { get; set; } = Array.Empty<Waypoint>();

        /// <summary>
        /// Array of Waypoint objects describing all destinations in order.
        /// </summary>
        [JsonPropertyName("destinations")]
        public Waypoint[] Destinations { get; set; } = Array.Empty<Waypoint>();

        /// <summary>
        /// (optional) array of arrays containing i,j pairs indicating which cells contain estimated values based on fallback_speed.
        /// Will be absent if fallback_speed is not used.
        /// </summary>
        [JsonPropertyName("fallback_speed_cells")]
        public int[][] FallbackSpeedCells { get; set; } = Array.Empty<int[]>();
    }
}
