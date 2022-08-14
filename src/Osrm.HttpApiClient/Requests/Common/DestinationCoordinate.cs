using System.Diagnostics;

namespace Osrm.HttpApiClient
{
    [DebuggerDisplay("{Value, nq}")]
    public record DestinationCoordinate
    {
        public DestinationCoordinate(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static readonly DestinationCoordinate Any = new ("any");
        public static readonly DestinationCoordinate Last = new ("last");
    }
}
