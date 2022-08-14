using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    public record Tracepoint : Waypoint
    {
        /// <summary>
        /// Index to the Route object in matchings the sub-trace was matched to.
        /// </summary>
        [JsonPropertyName("matchings_index")]
        public int MatchingsIndex { get; set; }

        /// <summary>
        /// Index of the waypoint inside the matched route.
        /// </summary>
        [JsonPropertyName("waypoint_index")]
        public int WaypointIndex { get; set; }

        /// <summary>
        /// Number of probable alternative matchings for this trace point.
        /// A value of zero indicate that this point was matched unambiguously.
        /// Split the trace at these points for incremental map matching.
        /// </summary>
        [JsonPropertyName("alternatives_count")]
        public int AlternativesCount { get; set; }
    }
}