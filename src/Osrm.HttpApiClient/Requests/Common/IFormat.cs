namespace Osrm.HttpApiClient
{
    public interface IFormat
    {
        public string Value { get; }
    }

    public readonly struct JsonFormat : IFormat
    {
        public string Value => "json";

        public static readonly JsonFormat Instance = new ();
    }

    public readonly struct FlatBuffersFormat : IFormat
    {
        public string Value => "flatbuffers";

        public static readonly FlatBuffersFormat Instance = new ();
    }
}
