using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    internal static class StringExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string Join<T>(this IEnumerable<T> collection, char separator)
            => string.Join(separator, collection);
    }
}
