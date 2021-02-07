using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Osrm.Examples;
using Osrm.HttpApiClient;

namespace Osrm.ConsoleExamples
{
    public class Program
    {
        private static readonly Uri _baseAddress = new Uri("http://router.project-osrm.org");

        private static readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions 
        {
            Converters =
            {
                new JsonStringEnumConverter()
            },
            WriteIndented = true
        };

        public static async Task Main()
        {
            using var httpClient = new HttpClient 
            {
                BaseAddress = _baseAddress
            };

            var osrmClient = new OsrmHttpApiClient(httpClient);

            await MakeOsrmRequest(ProjectOsrmOrgDocs.GeoJsonRoutes, request => osrmClient.GetRouteAsync(request));
            await MakeOsrmRequest(ProjectOsrmOrgDocs.PolylineRoutes, request => osrmClient.GetRouteAsync(request));
            await MakeOsrmRequest(ProjectOsrmOrgDocs.Nearests, request => osrmClient.GetNearestAsync(request));
            await MakeOsrmRequest(ProjectOsrmOrgDocs.Tables, request => osrmClient.GetTableAsync(request));
            await MakeOsrmRequest(ProjectOsrmOrgDocs.Trips, request => osrmClient.GetTripAsync(request));
        }

        private static async Task MakeOsrmRequest<TRequest, TResponse>(
            IEnumerable<TRequest> requests,
            Func<TRequest, Task<TResponse>> makeRequest)
            where TRequest : CommonRequest
            where TResponse : CommonResponse
        {
            foreach (var request in requests)
            {
                var response = await makeRequest(request);

                Console.WriteLine($"Request: {_baseAddress}{request.Uri}");
                Console.WriteLine($"Response:");
                Console.WriteLine(JsonSerializer.Serialize(response, _jsonSerializerOptions));
                Console.WriteLine();
            }
        }
    }
}
