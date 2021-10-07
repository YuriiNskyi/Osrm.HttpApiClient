using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    [DebuggerDisplay("{Value, nq}")]
    public record Alternatives
    {
        public Alternatives(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static readonly Alternatives True = new("true");
        public static readonly Alternatives False = new("false");

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Alternatives UpTo(int n) => new(n.ToString());
    }
}
