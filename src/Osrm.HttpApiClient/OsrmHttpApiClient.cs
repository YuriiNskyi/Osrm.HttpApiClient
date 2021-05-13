using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Osrm.HttpApiClient
{
    public class OsrmHttpApiClient
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
        public Task<NearestResponse> GetNearestAsync(
            NearestRequest request,
            CancellationToken cancellationToken = default)
            => MakeRequestAsync<NearestRequest, NearestResponse>(request, cancellationToken);

        /// <summary>
        /// Finds the fastest route between coordinates in the supplied order.
        /// </summary>
        /// <typeparam name="TGeometry">Geometry.</typeparam>
        /// <param name="request">Route request specified by Geometry.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Route response specified by Geometry.</returns>
        public Task<RouteResponse<TGeometry>> GetRouteAsync<TGeometry>(
            RouteRequest<TGeometry> request,
            CancellationToken cancellationToken = default)
            where TGeometry : Geometry
            => MakeRequestAsync<RouteRequest<TGeometry>, RouteResponse<TGeometry>>(request, cancellationToken);

        /// <summary>
        /// Computes the duration of the fastest route between all pairs of supplied coordinates.
        /// </summary>
        /// <param name="request">Table request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Table response.</returns>
        public Task<TableResponse> GetTableAsync(
            TableRequest request,
            CancellationToken cancellationToken = default)
            => MakeRequestAsync<TableRequest, TableResponse>(request, cancellationToken);

        /// <summary>
        /// Map matching matches/snaps given GPS points to the road network in the most plausible way. 
        /// </summary>
        /// <typeparam name="TGeometry">Geometry.</typeparam>
        /// <param name="request">Match request specified by Geometry.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Match response specified by Geometry.</returns>
        public Task<MatchResponse<TGeometry>> GetMatchAsync<TGeometry>(
            MatchRequest<TGeometry> request,
            CancellationToken cancellationToken = default)
            where TGeometry : Geometry
            => MakeRequestAsync<MatchRequest<TGeometry>, MatchResponse<TGeometry>>(request, cancellationToken);

        /// <summary>
        /// The trip plugin solves the Traveling Salesman Problem using a greedy heuristic (farthest-insertion algorithm).
        /// </summary>
        /// <typeparam name="TGeometry">Geometry.</typeparam>
        /// <param name="request">Trip request specified by Geometry.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Trip response specified by Geometry.</returns>
        public Task<TripResponse<TGeometry>> GetTripAsync<TGeometry>(
            TripRequest<TGeometry> request,
            CancellationToken cancellationToken = default)
            where TGeometry : Geometry
            => MakeRequestAsync<TripRequest<TGeometry>, TripResponse<TGeometry>>(request, cancellationToken);

        /// <summary>
        /// This service generates Mapbox Vector Tiles that can be viewed with a vector-tile capable slippy-map viewer.
        /// </summary>
        /// <param name="request">Tile request.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Tile response.</returns>
        public async Task<TileResponse> GetTileAsync(
            TileRequest request,
            CancellationToken cancellationToken = default)
        {
            var responseMessage = await _httpClient.GetAsync(request.Uri, cancellationToken).ConfigureAwait(false);

            var vectorTile = await responseMessage.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

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
        /// <param name="request">Common reqeust.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Common response.</returns>
        public async Task<TResponse> MakeRequestAsync<TRequest, TResponse>(
            TRequest request,
            CancellationToken cancellationToken = default)
            where TRequest : CommonRequest
            where TResponse : CommonResponse
        {
            var responseMessage = await _httpClient.GetAsync(request.Uri, cancellationToken).ConfigureAwait(false);

            var response = await Deserialize<TResponse>(responseMessage).ConfigureAwait(false);

            return response!;
        }

        private async Task<T> Deserialize<T>(HttpResponseMessage response)
        {
            var contentStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var result = await JsonSerializer.DeserializeAsync<T>(contentStream, JsonSerializerOptions).ConfigureAwait(false);

            return result!;
        }
    }
}
