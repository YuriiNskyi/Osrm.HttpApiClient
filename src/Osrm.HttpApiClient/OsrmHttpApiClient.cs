using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Osrm.HttpApiClient
{
    public class OsrmHttpApiClient
    {
        public static readonly JsonSerializerOptions DefaultJsonSerializerOptions = OsrmStaticHttpApiClient.DefaultJsonSerializerOptions;

        private readonly HttpClient _httpClient;
        private JsonSerializerOptions _jsonSerializerOptions = DefaultJsonSerializerOptions;

        public JsonSerializerOptions JsonSerializerOptions 
        {
            get => _jsonSerializerOptions;
            set => _jsonSerializerOptions = value ?? DefaultJsonSerializerOptions;
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="httpClient">Htpp client with already predefined BaseAddress.</param>
        public OsrmHttpApiClient(HttpClient httpClient)
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
        public Task<NearestResponse> GetNearestAsync(
            NearestRequest request,
            CancellationToken cancellationToken = default)
            => OsrmStaticHttpApiClient.GetNearestAsync(
                null,
                _httpClient,
                request,
                _jsonSerializerOptions,
                cancellationToken);

        /// <summary>
        /// Finds the fastest route between coordinates in the supplied order.
        /// </summary>
        /// <typeparam name="TGeometry">Geometry.</typeparam>
        /// <param name="request">Route request specified by Geometry.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Route response specified by Geometry.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Task<RouteResponse<TGeometry>> GetRouteAsync<TGeometry>(
            RouteRequest<TGeometry> request,
            CancellationToken cancellationToken = default)
            where TGeometry : Geometry
            => OsrmStaticHttpApiClient.GetRouteAsync(
                null,
                _httpClient,
                request,
                _jsonSerializerOptions,
                cancellationToken);

        /// <summary>
        /// Computes the duration of the fastest route between all pairs of supplied coordinates.
        /// </summary>
        /// <param name="request">Table request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Table response.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Task<TableResponse> GetTableAsync(
            TableRequest request,
            CancellationToken cancellationToken = default)
            => OsrmStaticHttpApiClient.GetTableAsync(
                null,
                _httpClient,
                request,
                _jsonSerializerOptions,
                cancellationToken);

        /// <summary>
        /// Map matching matches/snaps given GPS points to the road network in the most plausible way. 
        /// </summary>
        /// <typeparam name="TGeometry">Geometry.</typeparam>
        /// <param name="request">Match request specified by Geometry.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Match response specified by Geometry.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Task<MatchResponse<TGeometry>> GetMatchAsync<TGeometry>(
            MatchRequest<TGeometry> request,
            CancellationToken cancellationToken = default)
            where TGeometry : Geometry
            => OsrmStaticHttpApiClient.GetMatchAsync(
                null,
                _httpClient,
                request,
                _jsonSerializerOptions,
                cancellationToken);

        /// <summary>
        /// The trip plugin solves the Traveling Salesman Problem using a greedy heuristic (farthest-insertion algorithm).
        /// </summary>
        /// <typeparam name="TGeometry">Geometry.</typeparam>
        /// <param name="request">Trip request specified by Geometry.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Trip response specified by Geometry.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Task<TripResponse<TGeometry>> GetTripAsync<TGeometry>(
            TripRequest<TGeometry> request,
            CancellationToken cancellationToken = default)
            where TGeometry : Geometry
            => OsrmStaticHttpApiClient.GetTripAsync(
                null,
                _httpClient,
                request,
                _jsonSerializerOptions,
                cancellationToken);

        /// <summary>
        /// This service generates Mapbox Vector Tiles that can be viewed with a vector-tile capable slippy-map viewer.
        /// </summary>
        /// <param name="request">Tile request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Tile response.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Task<TileResponse> GetTileAsync(
            TileRequest request,
            CancellationToken cancellationToken = default)
            => OsrmStaticHttpApiClient.GetTileAsync(
                null,
                _httpClient,
                request,
                cancellationToken);
    }
}
