using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// {value},{range} integer 0 .. 360,integer 0 .. 180
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay, nq}")]
    public record Bearing
    {
        public double Value { get; }

        public double Range { get; }

        private Bearing(double value, double range)
        {
            Value = value;
            Range = range;
        }

        private string DebuggerDisplay
            => $"{Value}, {Range}";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Bearing Create(double value, double range = 0D)
            => new (value, range);
    }
}
