using System.Diagnostics;

namespace Osrm.HttpApiClient
{
    [DebuggerDisplay("{Value, nq}")]
    public record SourceCoordinate
    {
        public SourceCoordinate(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static readonly SourceCoordinate Any = new ("any");
        public static readonly SourceCoordinate First = new ("first");
    }
}
