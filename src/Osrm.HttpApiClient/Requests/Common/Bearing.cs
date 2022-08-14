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
        public int Value { get; }

        public int Range { get; }

        private Bearing(int value, int range)
        {
            Value = value switch
            {
                > 360 => value % 360,
                360 => 0,
                0 => 0,
                < 0 => 0,
                _ => value,
            };
            Range = range switch
            {
                > 180 => range % 180,
                180 => 0,
                0 => 0,
                < 0 => 0,
                _ => range,
            };
        }

        private string DebuggerDisplay
            => $"{Value}, {Range}";

        /// <summary>
        /// Creates new Bearing. Internally validates value and range to prevent InvalidOptions response from OSRM.
        /// </summary>
        /// <param name="value">[0, 360] If greater than 360, then taken by modulo 360. 360 is 0. If zero or less, then it is zero. Provided value otherwise.</param>
        /// <param name="range">[0, 180] If greater than 180, then taken by modulo 180. 180 is 0. If zero or less, then it is zero. Provided value otherwise.</param>
        /// <returns>The Bearing.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Bearing Create(int value, int range = 0)
            => new (value, range);
    }
}
