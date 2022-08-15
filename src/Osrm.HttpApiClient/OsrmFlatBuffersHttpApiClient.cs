using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Special OSRM client for FlatBuffers format.
    /// </summary>
    public class OsrmFlatBuffersHttpApiClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="httpClient">Htpp client with already predefined BaseAddress.</param>
        public OsrmFlatBuffersHttpApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Snaps a coordinate to the street network and returns the nearest n matches.
        /// </summary>
        /// <param name="request">Nearest request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Nearest response.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Task<FBResult> GetNearestAsync(
            NearestRequest<FlatBuffersFormat> request,
            CancellationToken cancellationToken = default)
            => OsrmFlatBuffersStaticHttpApiClient.GetNearestAsync(
                null,
                _httpClient,
                request,
                cancellationToken);

        /// <summary>
        /// Finds the fastest route between coordinates in the supplied order.
        /// </summary>
        /// <typeparam name="TGeometry">Geometry.</typeparam>
        /// <param name="request">Route request specified by Geometry.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Route response specified by Geometry.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Task<FBResult> GetRouteAsync<TGeometry>(
            RouteRequest<TGeometry, FlatBuffersFormat> request,
            CancellationToken cancellationToken = default)
            where TGeometry : Geometry
            => OsrmFlatBuffersStaticHttpApiClient.GetRouteAsync(
                null,
                _httpClient,
                request,
                cancellationToken);

        /// <summary>
        /// Computes the duration of the fastest route between all pairs of supplied coordinates.
        /// </summary>
        /// <param name="request">Table request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Table response.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Task<FBResult> GetTableAsync(
            TableRequest<FlatBuffersFormat> request,
            CancellationToken cancellationToken = default)
            => OsrmFlatBuffersStaticHttpApiClient.GetTableAsync(
                null,
                _httpClient,
                request,
                cancellationToken);

        /// <summary>
        /// Map matching matches/snaps given GPS points to the road network in the most plausible way. 
        /// </summary>
        /// <typeparam name="TGeometry">Geometry.</typeparam>
        /// <param name="request">Match request specified by Geometry.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Match response specified by Geometry.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Task<FBResult> GetMatchAsync<TGeometry>(
            MatchRequest<TGeometry, FlatBuffersFormat> request,
            CancellationToken cancellationToken = default)
            where TGeometry : Geometry
            => OsrmFlatBuffersStaticHttpApiClient.GetMatchAsync(
                null,
                _httpClient,
                request,
                cancellationToken);

        /// <summary>
        /// The trip plugin solves the Traveling Salesman Problem using a greedy heuristic (farthest-insertion algorithm).
        /// </summary>
        /// <typeparam name="TGeometry">Geometry.</typeparam>
        /// <param name="request">Trip request specified by Geometry.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Trip response specified by Geometry.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Task<FBResult> GetTripAsync<TGeometry>(
            TripRequest<TGeometry, FlatBuffersFormat> request,
            CancellationToken cancellationToken = default)
            where TGeometry : Geometry
            => OsrmFlatBuffersStaticHttpApiClient.GetTripAsync(
                null,
                _httpClient,
                request,
                cancellationToken);
    }
}
