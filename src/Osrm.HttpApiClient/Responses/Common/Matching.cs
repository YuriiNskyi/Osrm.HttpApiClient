using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    public record Matching<TGeometry> : Route<TGeometry>
        where TGeometry : Geometry
    {
        /// <summary>
        /// Confidence of the matching.
        /// Float value between 0 and 1.
        /// 1 is very confident that the matching is correct.
        /// </summary>
        [JsonPropertyName("confidence")]
        public float Confidence { get; set; }
    }
}
