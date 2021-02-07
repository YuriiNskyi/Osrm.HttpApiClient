using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// A step consists of a maneuver such as a turn or merge, followed by a distance of travel along a single way to the subsequent step.
    /// </summary>
    public record RouteStep<TGeometry>
        where TGeometry : Geometry
    {
        /// <summary>
        /// The distance traveled by the route, in float meters.
        /// </summary>
        [JsonPropertyName("distance")]
        public float Distance { get; set; }

        /// <summary>
        /// The estimated travel time, in float number of seconds.
        /// </summary>
        [JsonPropertyName("duration")]
        public float Duration { get; set; }

        /// <summary>
        /// The unsimplified geometry of the route segment, depending on the geometries parameter.
        /// </summary>
        [JsonPropertyName("geometry")]
        public TGeometry? Geometry { get; set; }

        /// <summary>
        /// The calculated weight of the step.
        /// </summary>
        [JsonPropertyName("weight")]
        public float Weight { get; set; }

        /// <summary>
        /// The name of the way along which travel proceeds.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// A reference number or code for the way. Optionally included, if ref data is available for the given way.
        /// </summary>
        [JsonPropertyName("ref")]
        public string Ref { get; set; } = null!;

        /// <summary>
        /// A string containing an IPA phonetic transcription indicating how to pronounce the name in the name property.
        /// This property is omitted if pronunciation data is unavailable for the step.
        /// </summary>
        [JsonPropertyName("pronunciation")]
        public string Pronunciation { get; set; } = null!;

        //public int Destinations { get; set; }

        //public int Exits { get; set; }

        /// <summary>
        /// A string signifying the mode of transportation.
        /// </summary>
        [JsonPropertyName("mode")]
        public string Mode { get; set; } = null!;

        /// <summary>
        /// A StepManeuver object representing the maneuver.
        /// </summary>
        [JsonPropertyName("maneuver")]
        public RouteStepManeuver Maneuver { get; set; } = null!;

        /// <summary>
        /// A list of Intersection objects that are passed along the segment, the very first belonging to the StepManeuver.
        /// </summary>
        [JsonPropertyName("intersections")]
        public RouteStepIntersections[] Intersections { get; set; } = null!;

        /// <summary>
        /// The name for the rotary. Optionally included, if the step is a rotary and a rotary name is available.
        /// </summary>
        [JsonPropertyName("rotary_name")]
        public string RotaryName { get; set; } = null!;

        /// <summary>
        /// The pronunciation hint of the rotary name. Optionally included, if the step is a rotary and a rotary pronunciation is available.
        /// </summary>
        [JsonPropertyName("rotary_pronunciation")]
        public string RotaryPronunciation { get; set; } = null!;

        /// <summary>
        /// The legal driving side at the location for this step. Either left or right.
        /// </summary>
        [JsonPropertyName("driving_side")]
        public string DrivingSide { get; set; } = null!;
    }
}
