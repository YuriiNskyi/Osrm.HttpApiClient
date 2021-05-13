using System.Diagnostics;

namespace Osrm.HttpApiClient
{
    [DebuggerDisplay("{Value, nq}")]
    public record FallbackCoordinate
    {
        public FallbackCoordinate(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static readonly FallbackCoordinate Input = new ("input");
        public static readonly FallbackCoordinate Snapped = new ("snapped");
    }
}
