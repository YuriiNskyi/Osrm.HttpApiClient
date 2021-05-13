using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    internal static class BoolExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static string ToLowerInvariant(this bool b)
            => b.ToString().ToLowerInvariant();
    }
}
