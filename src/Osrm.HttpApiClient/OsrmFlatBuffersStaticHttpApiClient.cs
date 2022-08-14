using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using FlatSharp;

namespace Osrm.HttpApiClient
{
    public static class OsrmFlatBuffersStaticHttpApiClient
    {
        /// <summary>
        /// Snaps a coordinate to the street network and returns the nearest n matches.
        /// </summary>
        /// <param name="baseAddress">Base address for the OSRM backend.</param>
        /// <param name="httpClient">Http client which is responsible for sending actual request.</param>
        /// <param name="request">Nearest request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Nearest response.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<FBResult> GetNearestAsync(
            string? baseAddress,
            HttpClient httpClient,
            NearestRequest<FlatBuffersFormat> request,
            CancellationToken cancellationToken = default)
            => MakeRequestAsync(
                baseAddress,
                httpClient,
                request,
                cancellationToken);

        /// <summary>
        /// Finds the fastest route between coordinates in the supplied order.
        /// </summary>
        /// <typeparam name="TGeometry">Geometry.</typeparam>
        /// <param name="baseAddress">Base address for the OSRM backend.</param>
        /// <param name="httpClient">Http client which is responsible for sending actual request.</param>
        /// <param name="request">Route request specified by Geometry.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Route response specified by Geometry.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<FBResult> GetRouteAsync<TGeometry>(
            string? baseAddress,
            HttpClient httpClient,
            RouteRequest<TGeometry, FlatBuffersFormat> request,
            CancellationToken cancellationToken = default)
            where TGeometry : Geometry
            => MakeRequestAsync(
                baseAddress,
                httpClient,
                request,
                cancellationToken);

        /// <summary>
        /// Computes the duration of the fastest route between all pairs of supplied coordinates.
        /// </summary>
        /// <param name="baseAddress">Base address for the OSRM backend.</param>
        /// <param name="httpClient">Http client which is responsible for sending actual request.</param>
        /// <param name="request">Table request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Table response.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<FBResult> GetTableAsync(
            string? baseAddress,
            HttpClient httpClient,
            TableRequest<FlatBuffersFormat> request,
            CancellationToken cancellationToken = default)
            => MakeRequestAsync(
                baseAddress,
                httpClient,
                request,
                cancellationToken);

        /// <summary>
        /// Map matching matches/snaps given GPS points to the road network in the most plausible way. 
        /// </summary>
        /// <typeparam name="TGeometry">Geometry.</typeparam>
        /// <param name="baseAddress">Base address for the OSRM backend.</param>
        /// <param name="httpClient">Http client which is responsible for sending actual request.</param>
        /// <param name="request">Match request specified by Geometry.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Match response specified by Geometry.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<FBResult> GetMatchAsync<TGeometry>(
            string? baseAddress,
            HttpClient httpClient,
            MatchRequest<TGeometry, FlatBuffersFormat> request,
            CancellationToken cancellationToken = default)
            where TGeometry : Geometry
            => MakeRequestAsync(
                baseAddress,
                httpClient,
                request,
                cancellationToken);

        /// <summary>
        /// The trip plugin solves the Traveling Salesman Problem using a greedy heuristic (farthest-insertion algorithm).
        /// </summary>
        /// <typeparam name="TGeometry">Geometry.</typeparam>
        /// <param name="baseAddress">Base address for the OSRM backend.</param>
        /// <param name="httpClient">Http client which is responsible for sending actual request.</param>
        /// <param name="request">Trip request specified by Geometry.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Trip response specified by Geometry.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<FBResult> GetTripAsync<TGeometry>(
            string? baseAddress,
            HttpClient httpClient,
            TripRequest<TGeometry, FlatBuffersFormat> request,
            CancellationToken cancellationToken = default)
            where TGeometry : Geometry
            => MakeRequestAsync(
                baseAddress,
                httpClient,
                request,
                cancellationToken);

        /// <summary>
        /// A general way to make requests.
        /// </summary>
        /// <typeparam name="TRequest">Common request.</typeparam>
        /// <typeparam name="TResponse">Common response.</typeparam>
        /// <param name="baseAddress">Base address for the OSRM backend.</param>
        /// <param name="httpClient">Http client which is responsible for sending actual request.</param>
        /// <param name="request">Common reqeust.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Common response.</returns>
        public static async Task<FBResult> MakeRequestAsync<TRequest>(
            string? baseAddress,
            HttpClient httpClient,
            TRequest request,
            CancellationToken cancellationToken = default)
            where TRequest : CommonRequest<FlatBuffersFormat>
        {
            var requestUri = OsrmBaseStaticHttpApiClient.BuildRequestUri(baseAddress, request);

            var responseMessage = await httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            var response = await Deserialize(responseMessage, cancellationToken).ConfigureAwait(false);

            return response!;
        }

        private static async Task<FBResult> Deserialize(
            HttpResponseMessage response,
            CancellationToken cancellationToken = default)
        {
            var responseBytes = await response.Content.ReadAsByteArrayAsync(cancellationToken).ConfigureAwait(false);

            var result = FlatBufferSerializer.Default.Parse<FBResult>(responseBytes);

            return result!;
        }
    }
}
