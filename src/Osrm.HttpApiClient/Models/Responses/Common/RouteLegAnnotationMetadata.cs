using System;
using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Metadata related to other annotations.
    /// </summary>
    public record RouteLegAnnotationMetadata
    {
        /// <summary>
        /// The names of the datasources used for the speed between each pair of coordinates.
        /// lua profile is the default profile, other values arethe filenames supplied via --segment-speed-file to osrm-contract or osrm-customize.
        /// </summary>
        [JsonPropertyName("datasource_names")]
        public string[] DatasourceNames { get; set; } = Array.Empty<string>();
    }
}