using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Special JSON converter for handling Polyline6 Geometry.
    /// </summary>
    public class Polyline6GeometryConverter : JsonConverter<Polyline6Geometry>
    {
        ///<inheritdoc />
        public override bool CanConvert(Type typeToConvert)
            => typeToConvert == typeof(Polyline6Geometry);

        ///<inheritdoc />
        public override Polyline6Geometry Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => new Polyline6Geometry
            {
                Value = reader.GetString()!,
            };

        ///<inheritdoc />
        public override void Write(Utf8JsonWriter writer, Polyline6Geometry value, JsonSerializerOptions options)
            => writer.WriteStringValue(value.Value);
    }
}
