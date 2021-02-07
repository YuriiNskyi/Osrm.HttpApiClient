using System;
using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// An intersection gives a full representation of any cross-way the path passes bay.
    /// For every step, the very first intersection (intersections[0]) corresponds to the location of the StepManeuver.
    /// Further intersections are listed for every cross-way until the next turn instruction.
    /// </summary>
    public record RouteStepIntersections
    {
        /// <summary>
        /// A [longitude, latitude] pair describing the location of the turn.
        /// </summary>
        [JsonPropertyName("location")]
        public float[] Location { get; set; } = Array.Empty<float>();

        /// <summary>
        /// A list of bearing values (e.g. [0,90,180,270]) that are available at the intersection.
        /// The bearings describe all available roads at the intersection.
        /// Values are between 0-359 (0=true north)
        /// </summary>
        [JsonPropertyName("bearings")]
        public int[] Bearings { get; set; } = Array.Empty<int>();

        /// <summary>
        /// An array of strings signifying the classes (as specified in the profile) of the road exiting the intersection.
        /// </summary>
        [JsonPropertyName("classes")]
        public string[] Classes { get; set; } = Array.Empty<string>();

        /// <summary>
        /// A list of entry flags, corresponding in a 1:1 relationship to the bearings.
        /// A value of true indicates that the respective road could be entered on a valid route.
        /// false indicates that the turn onto the respective road would violate a restriction.
        /// </summary>
        [JsonPropertyName("entry")]
        public bool[] Entry { get; set; } = Array.Empty<bool>();

        /// <summary>
        /// Index into bearings/entry array.
        /// Used to calculate the bearing just before the turn.
        /// Namely, the clockwise angle from true north to the direction of travel immediately before the maneuver/passing the intersection.
        /// Bearings are given relative to the intersection.
        /// To get the bearing in the direction of driving, the bearing has to be rotated by a value of 180.
        /// The value is not supplied for depart maneuvers.
        /// </summary>
        [JsonPropertyName("in")]
        public int In { get; set; }

        /// <summary>
        /// Index into the bearings/entry array.
        /// Used to extract the bearing just after the turn.
        /// Namely, The clockwise angle from true north to the direction of travel immediately after the maneuver/passing the intersection.
        /// The value is not supplied for arrive maneuvers.
        /// </summary>
        [JsonPropertyName("out")]
        public int Out { get; set; }

        /// <summary>
        /// Array of Lane objects that denote the available turn lanes at the intersection.
        /// If no lane information is available for an intersection, the lanes property will not be present.
        /// </summary>
        [JsonPropertyName("lanes")]
        public RouteStepIntersectionLane[] Lanes { get; set; } = Array.Empty<RouteStepIntersectionLane>();
    }
}
