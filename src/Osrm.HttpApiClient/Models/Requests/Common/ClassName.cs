using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    [DebuggerDisplay("{Value, nq}")]
    public record ClassName
    {
        public ClassName(string value)
        {
            Value = value;
        }

        public string Value { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ClassName From(string name) => new (name);
        public static readonly ClassName None = new ("none");
    }
}
