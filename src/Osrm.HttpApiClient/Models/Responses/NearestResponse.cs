using System;
using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    public record NearestResponse : CommonResponse
    {
        /// <summary>
        /// Array of Waypoint objects sorted by distance to the input coordinate.
        /// </summary>
        [JsonPropertyName("waypoints")]
        public Waypoint[] Waypoints { get; set; } = Array.Empty<Waypoint>();
    }
}
