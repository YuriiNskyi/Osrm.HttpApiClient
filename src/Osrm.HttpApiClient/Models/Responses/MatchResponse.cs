using System;
using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    public record MatchResponse<TGeometry> : CommonResponse
        where TGeometry : Geometry
    {
        /// <summary>
        /// Array of Waypoint objects representing all points of the trace in order.
        /// If the trace point was ommited by map matching because it is an outlier, the entry will be null.
        /// </summary>
        [JsonPropertyName("tracepoints")]
        public Tracepoint[] Tracepoints { get; set; } = Array.Empty<Tracepoint>();

        /// <summary>
        /// An array of Route objects that assemble the trace.
        /// </summary>
        [JsonPropertyName("matchings")]
        public Matching<TGeometry>[] Matchings { get; set; } = Array.Empty<Matching<TGeometry>>();
    }
}
