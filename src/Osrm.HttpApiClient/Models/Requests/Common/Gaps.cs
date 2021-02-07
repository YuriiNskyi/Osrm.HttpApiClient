using System.Diagnostics;

namespace Osrm.HttpApiClient
{
    [DebuggerDisplay("{Value, nq}")]
    public record Gaps
    {
        public Gaps(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static readonly Gaps Split = new ("split");
        public static readonly Gaps Ignore = new ("ignore");
    }
}
