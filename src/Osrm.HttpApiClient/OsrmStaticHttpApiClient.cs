using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Osrm.HttpApiClient
{
    public static class OsrmStaticHttpApiClient
    {
        public static readonly JsonSerializerOptions DefaultJsonSerializerOptions = new()
        {
            Converters =
            {
                new JsonStringEnumConverter(),
                new PolylineGeometryConverter(),
                new Polyline6GeometryConverter(),
            }
        };

        /// <summary>
        /// Snaps a coordinate to the street network and returns the nearest n matches.
        /// </summary>
        /// <param name="baseAddress">Base address for the OSRM backend.</param>
        /// <param name="httpClient">Http client which is responsible for sending actual request.</param>
        /// <param name="request">Nearest request.</param>
        /// <param name="jsonSerializerOptions">JSON serializer options for response.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Nearest response.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<NearestResponse> GetNearestAsync(
            string? baseAddress,
            HttpClient httpClient,
            NearestRequest<JsonFormat> request,
            JsonSerializerOptions? jsonSerializerOptions = null,
            CancellationToken cancellationToken = default)
            => MakeRequestAsync<NearestRequest<JsonFormat>, NearestResponse>(
                baseAddress,
                httpClient,
                request,
                jsonSerializerOptions,
                cancellationToken);

        /// <summary>
        /// Finds the fastest route between coordinates in the supplied order.
        /// </summary>
        /// <typeparam name="TGeometry">Geometry.</typeparam>
        /// <param name="baseAddress">Base address for the OSRM backend.</param>
        /// <param name="httpClient">Http client which is responsible for sending actual request.</param>
        /// <param name="request">Route request specified by Geometry.</param>
        /// <param name="jsonSerializerOptions">JSON serializer options for response.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Route response specified by Geometry.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<RouteResponse<TGeometry>> GetRouteAsync<TGeometry>(
            string? baseAddress,
            HttpClient httpClient,
            RouteRequest<TGeometry, JsonFormat> request,
            JsonSerializerOptions? jsonSerializerOptions = null,
            CancellationToken cancellationToken = default)
            where TGeometry : Geometry
            => MakeRequestAsync<RouteRequest<TGeometry, JsonFormat>, RouteResponse<TGeometry>>(
                baseAddress,
                httpClient,
                request,
                jsonSerializerOptions,
                cancellationToken);

        /// <summary>
        /// Computes the duration of the fastest route between all pairs of supplied coordinates.
        /// </summary>
        /// <param name="baseAddress">Base address for the OSRM backend.</param>
        /// <param name="httpClient">Http client which is responsible for sending actual request.</param>
        /// <param name="request">Table request.</param>
        /// <param name="jsonSerializerOptions">JSON serializer options for response.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Table response.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<TableResponse> GetTableAsync(
            string? baseAddress,
            HttpClient httpClient,
            TableRequest<JsonFormat> request,
            JsonSerializerOptions? jsonSerializerOptions = null,
            CancellationToken cancellationToken = default)
            => MakeRequestAsync<TableRequest<JsonFormat>, TableResponse>(
                baseAddress,
                httpClient,
                request,
                jsonSerializerOptions,
                cancellationToken);

        /// <summary>
        /// Map matching matches/snaps given GPS points to the road network in the most plausible way. 
        /// </summary>
        /// <typeparam name="TGeometry">Geometry.</typeparam>
        /// <param name="baseAddress">Base address for the OSRM backend.</param>
        /// <param name="httpClient">Http client which is responsible for sending actual request.</param>
        /// <param name="request">Match request specified by Geometry.</param>
        /// <param name="jsonSerializerOptions">JSON serializer options for response.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Match response specified by Geometry.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<MatchResponse<TGeometry>> GetMatchAsync<TGeometry>(
            string? baseAddress,
            HttpClient httpClient,
            MatchRequest<TGeometry, JsonFormat> request,
            JsonSerializerOptions? jsonSerializerOptions = null,
            CancellationToken cancellationToken = default)
            where TGeometry : Geometry
            => MakeRequestAsync<MatchRequest<TGeometry, JsonFormat>, MatchResponse<TGeometry>>(
                baseAddress,
                httpClient,
                request,
                jsonSerializerOptions,
                cancellationToken);

        /// <summary>
        /// The trip plugin solves the Traveling Salesman Problem using a greedy heuristic (farthest-insertion algorithm).
        /// </summary>
        /// <typeparam name="TGeometry">Geometry.</typeparam>
        /// <param name="baseAddress">Base address for the OSRM backend.</param>
        /// <param name="httpClient">Http client which is responsible for sending actual request.</param>
        /// <param name="request">Trip request specified by Geometry.</param>
        /// <param name="jsonSerializerOptions">JSON serializer options for response.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Trip response specified by Geometry.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Task<TripResponse<TGeometry>> GetTripAsync<TGeometry>(
            string? baseAddress,
            HttpClient httpClient,
            TripRequest<TGeometry, JsonFormat> request,
            JsonSerializerOptions? jsonSerializerOptions = null,
            CancellationToken cancellationToken = default)
            where TGeometry : Geometry
            => MakeRequestAsync<TripRequest<TGeometry, JsonFormat>, TripResponse<TGeometry>>(
                baseAddress,
                httpClient,
                request,
                jsonSerializerOptions,
                cancellationToken);

        /// <summary>
        /// This service generates Mapbox Vector Tiles that can be viewed with a vector-tile capable slippy-map viewer.
        /// </summary>
        /// <param name="baseAddress">Base address for the OSRM backend.</param>
        /// <param name="httpClient">Http client which is responsible for sending actual request.</param>
        /// <param name="request">Tile request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Tile response.</returns>
        public static async Task<TileResponse> GetTileAsync(
            string? baseAddress,
            HttpClient httpClient,
            TileRequest request,
            CancellationToken cancellationToken = default)
        {
            var requestUri = OsrmBaseStaticHttpApiClient.BuildRequestUri(baseAddress, request);

            var responseMessage = await httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            var vectorTile = await responseMessage.Content.ReadAsByteArrayAsync(cancellationToken).ConfigureAwait(false);

            var response = new TileResponse
            {
                VectorTile = vectorTile
            };

            return response;
        }

        /// <summary>
        /// A general way to make requests.
        /// </summary>
        /// <typeparam name="TRequest">Common request.</typeparam>
        /// <typeparam name="TResponse">Common response.</typeparam>
        /// <param name="baseAddress">Base address for the OSRM backend.</param>
        /// <param name="httpClient">Http client which is responsible for sending actual request.</param>
        /// <param name="request">Common reqeust.</param>
        /// <param name="jsonSerializerOptions">JSON serializer options for response.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Common response.</returns>
        public static async Task<TResponse> MakeRequestAsync<TRequest, TResponse>(
            string? baseAddress,
            HttpClient httpClient,
            TRequest request,
            JsonSerializerOptions? jsonSerializerOptions = null,
            CancellationToken cancellationToken = default)
            where TRequest : CommonRequest<JsonFormat>
            where TResponse : CommonResponse
        {
            var requestUri = OsrmBaseStaticHttpApiClient.BuildRequestUri(baseAddress, request);

            var responseMessage = await httpClient.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);

            var response = await Deserialize<TResponse>(responseMessage, jsonSerializerOptions, cancellationToken).ConfigureAwait(false);

            return response!;
        }

        private static async Task<T> Deserialize<T>(
            HttpResponseMessage response,
            JsonSerializerOptions? jsonSerializerOptions = null,
            CancellationToken cancellationToken = default)
        {
            var contentStream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);

            var result = await JsonSerializer.DeserializeAsync<T>(contentStream, jsonSerializerOptions ?? DefaultJsonSerializerOptions).ConfigureAwait(false);

            return result!;
        }
    }
}
