using System;
using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    public record RouteStepManeuver
    {
        /// <summary>
        /// A [longitude, latitude] pair describing the location of the turn.
        /// </summary>
        [JsonPropertyName("location")]
        public double[] Location { get; set; } = Array.Empty<double>();

        /// <summary>
        /// The clockwise angle from true north to the direction of travel immediately before the maneuver. Range 0-359.
        /// </summary>
        [JsonPropertyName("bearing_before")]
        public int BearingBefore { get; set; }

        /// <summary>
        /// The clockwise angle from true north to the direction of travel immediately after the maneuver. Range 0-359.
        /// </summary>
        [JsonPropertyName("bearing_after")]
        public int BearingAfter { get; set; }

        /// <summary>
        /// A string indicating the type of maneuver. 
        /// New identifiers might be introduced without API change Types unknown to the client should be handled like the turn type, the existence of correct modifier values is guranteed.
        /// Please note that even though there are new name and notification instructions, the mode and name can change between all instructions.
        /// They only offer a fallback in case nothing else is to report.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;

        /// <summary>
        /// An optional string indicating the direction change of the maneuver.
        /// </summary>
        [JsonPropertyName("modifier")]
        public string Modifier { get; set; } = null!;

        /// <summary>
        /// An optional integer indicating number of the exit to take.
        /// The property exists for the roundabout / rotary property: Number of the roundabout exit to take.
        /// If exit is undefined the destination is on the roundabout.
        /// </summary>
        [JsonPropertyName("exit")]
        public int Exit { get; set; }
    }
}
