using System;
using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Annotation of the whole route leg with fine-grained information about each segment or node id.
    /// </summary>
    public record RouteLegAnnotation
    {
        /// <summary>
        /// The distance, in metres, between each pair of coordinates.
        /// </summary>
        [JsonPropertyName("distance")]
        public float[] Distance { get; set; } = Array.Empty<float>();

        /// <summary>
        /// The duration between each pair of coordinates, in seconds. Does not include the duration of any turns.
        /// </summary>
        [JsonPropertyName("duration")]
        public float[] Duration { get; set; } = Array.Empty<float>();

        /// <summary>
        /// The index of the datasource for the speed between each pair of coordinates.
        /// 0 is the default profile, other values are supplied via --segment-speed-file to osrm-contract or osrm-customize.
        /// String-like names are in the metadata.datasource_names array.
        /// </summary>
        [JsonPropertyName("datasources")]
        public int[] Datasources { get; set; } = Array.Empty<int>();

        /// <summary>
        /// The OSM node ID for each coordinate along the route, excluding the first/last user-supplied coordinates.
        /// </summary>
        [JsonPropertyName("nodes")]
        public long[] Nodes { get; set; } = Array.Empty<long>();

        /// <summary>
        /// The weights between each pair of coordinates. Does not include any turn costs.
        /// </summary>
        [JsonPropertyName("weight")]
        public float[] Weight { get; set; } = Array.Empty<float>();

        /// <summary>
        /// Convenience field, calculation of distance / duration rounded to one decimal place.
        /// </summary>
        [JsonPropertyName("speed")]
        public float[] Speed { get; set; } = Array.Empty<float>();

        /// <summary>
        /// Metadata related to other annotations.
        /// </summary>
        [JsonPropertyName("metadata")]
        public RouteLegAnnotationMetadata Metadata { get; set; } = null!;
    }
}