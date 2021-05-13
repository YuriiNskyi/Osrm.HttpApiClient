using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Special JSON converter for handling Polyline Geometry.
    /// </summary>
    public class PolylineGeometryConverter : JsonConverter<PolylineGeometry>
    {
        ///<inheritdoc />
        public override bool CanConvert(Type typeToConvert) 
            => typeToConvert == typeof(PolylineGeometry);

        ///<inheritdoc />
        public override PolylineGeometry Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) 
            => new PolylineGeometry
            {
                Value = reader.GetString()!,
            };

        ///<inheritdoc />
        public override void Write(Utf8JsonWriter writer, PolylineGeometry value, JsonSerializerOptions options) 
            => writer.WriteStringValue(value.Value);
    }
}
