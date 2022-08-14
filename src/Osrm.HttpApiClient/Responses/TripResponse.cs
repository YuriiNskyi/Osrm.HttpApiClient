using System;
using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    public record TripResponse<TGeometry> : CommonResponse
        where TGeometry : Geometry
    {
        /// <summary>
        /// Array of Waypoint objects representing all waypoints in input order.
        /// </summary>
        [JsonPropertyName("waypoints")]
        public TripWaypoint[] Waypoints { get; set; } = Array.Empty<TripWaypoint>();

        /// <summary>
        /// An array of Route objects that assemble the trace.
        /// </summary>
        [JsonPropertyName("trips")]
        public Route<TGeometry>[] Trips { get; set; } = Array.Empty<Route<TGeometry>>();
    }
}
