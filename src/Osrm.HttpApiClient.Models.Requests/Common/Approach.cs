using System.Diagnostics;

namespace Osrm.HttpApiClient
{
    [DebuggerDisplay("{Value, nq}")]
    public record Approach
    {
        public Approach(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static readonly Approach Curb = new ("curb");
        public static readonly Approach Unrestricted = new ("unrestricted");
    }
}
