using System.Diagnostics;

namespace Osrm.HttpApiClient
{
    [DebuggerDisplay("{Value, nq}")]
    public record ContinueStraight
    {
        public ContinueStraight(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static readonly ContinueStraight Default = new ("default");
        public static readonly ContinueStraight True = new ("true");
        public static readonly ContinueStraight False = new ("false");
    }
}
