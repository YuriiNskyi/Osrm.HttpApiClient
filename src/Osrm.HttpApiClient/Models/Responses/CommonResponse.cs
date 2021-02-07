using System.Text.Json.Serialization;

namespace Osrm.HttpApiClient
{
    public abstract record CommonResponse
    {
        [JsonPropertyName("code")]
        public ResponseCode Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; } = null!;

        [JsonIgnore]
        public bool IsValid => Code == ResponseCode.Ok;
    }
}
