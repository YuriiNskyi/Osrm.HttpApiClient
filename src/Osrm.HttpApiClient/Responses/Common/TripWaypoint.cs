using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    public record TripWaypoint : Waypoint
    {
        /// <summary>
        /// Index to trips of the sub-trip the point was matched to.
        /// </summary>
        [JsonPropertyName("trips_index")]
        public int TripsIndex { get; set; }

        /// <summary>
        /// Index of the point in the trip.
        /// </summary>
        [JsonPropertyName("waypoint_index")]
        public int WaypointIndex { get; set; }
    }
}