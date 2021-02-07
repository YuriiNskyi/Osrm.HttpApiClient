using System.Globalization;
using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    internal static class NumberExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string InvariantCulture(this double number)
            => number.ToString(CultureInfo.InvariantCulture);
    }
}
