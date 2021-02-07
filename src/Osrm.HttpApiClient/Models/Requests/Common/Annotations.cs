using System.Diagnostics;

namespace Osrm.HttpApiClient
{
    [DebuggerDisplay("{Value, nq}")]
    public record Annotations
    {
        public Annotations(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static readonly Annotations Duration = new ("duration");
        public static readonly Annotations Distance = new ("distance");
        public static readonly Annotations DurationAndDistance = new ("duration,distance");
    }
}
