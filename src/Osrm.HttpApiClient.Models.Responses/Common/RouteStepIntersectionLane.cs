using System;
using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// A Lane represents a turn lane at the corresponding turn location.
    /// </summary>
    public record RouteStepIntersectionLane
    {
        /// <summary>
        /// An indication (e.g. marking on the road) specifying the turn lane.
        /// A road can have multiple indications (e.g. an arrow pointing straight and left).
        /// The indications are given in an array, each containing one of the following types.
        /// Further indications might be added on without an API version change.
        /// </summary>
        [JsonPropertyName("indications")]
        public string[] Indications { get; set; } = Array.Empty<string>();

        /// <summary>
        /// A boolean flag indicating whether the lane is a valid choice in the current maneuver.
        /// </summary>
        [JsonPropertyName("valid")]
        public bool Valid { get; set; }
    }
}
