using System.Net;
using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    internal static class OsrmBaseStaticHttpApiClient
    {
        private const char Slash = '/';

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string BuildRequestUri<TRequest>(string? baseAddress, TRequest request)
            where TRequest : IOsrmRequest
            => string.IsNullOrWhiteSpace(baseAddress)
                ? request.Uri
                : baseAddress.TrimEnd(Slash) + Slash + request.Uri;

        public static bool IsSuccessResponseStatusCode(HttpStatusCode httpStatusCode)
            => httpStatusCode is HttpStatusCode.OK or HttpStatusCode.BadRequest;
    }
}
