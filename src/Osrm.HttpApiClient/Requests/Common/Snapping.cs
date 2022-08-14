using System.Diagnostics;

namespace Osrm.HttpApiClient
{
    [DebuggerDisplay("{Value, nq}")]
    public record Snapping
    {
        public Snapping(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static readonly Snapping Default = new ("default");
        public static readonly Snapping Any = new ("any");
    }
}
