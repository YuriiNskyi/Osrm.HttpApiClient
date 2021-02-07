using System;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Abstract Geometry type which is used by requests and response.
    /// </summary>
    public abstract record Geometry
    {
    }
    
    [DebuggerDisplay("{Value, nq}")]

    public record PolylineGeometry : Geometry
    {
        /// <summary>
        /// Name of the Geometry. Used in requests.
        /// </summary>
        public const string Name = "polyline";

        /// <summary>
        /// Gets and sets value for response.
        /// </summary>
        public string Value { get; set; } = null!;
    }

    [DebuggerDisplay("{Value, nq}")]
    public record Polyline6Geometry : Geometry
    {
        /// <summary>
        /// Name of the Geometry. Used in requests.
        /// </summary>
        public const string Name = "polyline6";

        /// <summary>
        /// Gets and sets value for response.
        /// </summary>
        public string Value { get; set; } = null!;
    }

    public record GeoJsonGeometry : Geometry
    {
        /// <summary>
        /// Name of the Geometry. Used in requests.
        /// </summary>
        public const string Name = "geojson";

        /// <summary>
        /// Gets and sets coordinates for response.
        /// </summary>
        [JsonPropertyName("coordinates")]
        public float[][] Coordinates { get; set; } = Array.Empty<float[]>();
    }
}
