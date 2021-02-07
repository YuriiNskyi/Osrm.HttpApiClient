using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using NUnit.Framework;
using Osrm.Examples;
using Osrm.HttpApiClient;

namespace Osrm.IntegrationTests
{
    [UseApprovalSubdirectory("Approvals")]
    [UseReporter(typeof(VisualStudioReporter))]
    public class OsrmHttpApiClientTests
    {
        private HttpClient _httpClient;
        private OsrmHttpApiClient _osrmClient;

        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://router.project-osrm.org"),
            };

            _osrmClient = new OsrmHttpApiClient(_httpClient);
        }

        [TearDown]
        public void Teardown()
        {
            _osrmClient = null;
            _httpClient.Dispose();
        }

        [Test]
        public async Task Full_GeoJson_route_query()
        {
            var response = await _osrmClient.GetRouteAsync(ProjectOsrmOrgDocs.Full_GeoJson_route_query);

            var json = JsonSerializer.Serialize(response, OsrmHttpApiClient.DefaultJsonSerializerOptions);

            Approvals.VerifyJson(json);
        }

        [Test]
        public async Task Full_Polyline_route_query()
        {
            var response = await _osrmClient.GetRouteAsync(ProjectOsrmOrgDocs.Full_Polyline_route_query);

            var json = JsonSerializer.Serialize(response, OsrmHttpApiClient.DefaultJsonSerializerOptions);

            Approvals.VerifyJson(json);
        }

        [Test]
        public async Task Query_on_Berlin_with_three_coordinates()
        {
            var response = await _osrmClient.GetRouteAsync(ProjectOsrmOrgDocs.Query_on_Berlin_with_three_coordinates);

            var json = JsonSerializer.Serialize(response, OsrmHttpApiClient.DefaultJsonSerializerOptions);

            Approvals.VerifyJson(json);
        }

        [Test]
        public async Task Query_on_Berlin_excluding_the_usage_of_motorways()
        {
            var response = await _osrmClient.GetRouteAsync(ProjectOsrmOrgDocs.Query_on_Berlin_excluding_the_usage_of_motorways);

            var json = JsonSerializer.Serialize(response, OsrmHttpApiClient.DefaultJsonSerializerOptions);

            Approvals.VerifyJson(json);
        }

        [Test]
        public async Task Query_on_Berlin_using_polyline()
        {
            var response = await _osrmClient.GetRouteAsync(ProjectOsrmOrgDocs.Query_on_Berlin_using_polyline);

            var json = JsonSerializer.Serialize(response, OsrmHttpApiClient.DefaultJsonSerializerOptions);

            Approvals.VerifyJson(json);
        }

        [Test]
        public async Task Querying_nearest_three_snapped_locations()
        {
            var response = await _osrmClient.GetNearestAsync(ProjectOsrmOrgDocs.Querying_nearest_three_snapped_locations);

            var json = JsonSerializer.Serialize(response, OsrmHttpApiClient.DefaultJsonSerializerOptions);

            Approvals.VerifyJson(json);
        }

        [Test]
        public async Task A_3x3_matrix()
        {
            var response = await _osrmClient.GetTableAsync(ProjectOsrmOrgDocs.A_3x3_matrix);

            var json = JsonSerializer.Serialize(response, OsrmHttpApiClient.DefaultJsonSerializerOptions);

            Approvals.VerifyJson(json);
        }

        [Test]
        public async Task A_1x3_duration_matrix()
        {
            var response = await _osrmClient.GetTableAsync(ProjectOsrmOrgDocs.A_1x3_duration_matrix);

            var json = JsonSerializer.Serialize(response, OsrmHttpApiClient.DefaultJsonSerializerOptions);

            Approvals.VerifyJson(json);
        }

        [Test]
        public async Task An_asymmetric_3x2_duration_matrix_with_from_the_polyline_encoded_locations()
        {
            var response = await _osrmClient.GetTableAsync(ProjectOsrmOrgDocs.An_asymmetric_3x2_duration_matrix_with_from_the_polyline_encoded_locations);

            var json = JsonSerializer.Serialize(response, OsrmHttpApiClient.DefaultJsonSerializerOptions);

            Approvals.VerifyJson(json);
        }

        [Test]
        public async Task A_3x3_duration_matrix()
        {
            var response = await _osrmClient.GetTableAsync(ProjectOsrmOrgDocs.A_3x3_duration_matrix);

            var json = JsonSerializer.Serialize(response, OsrmHttpApiClient.DefaultJsonSerializerOptions);

            Approvals.VerifyJson(json);
        }

        [Test]
        public async Task A_3x3_duration_matrix_for_CH()
        {
            var response = await _osrmClient.GetTableAsync(ProjectOsrmOrgDocs.A_3x3_duration_matrix_for_CH);

            var json = JsonSerializer.Serialize(response, OsrmHttpApiClient.DefaultJsonSerializerOptions);

            Approvals.VerifyJson(json);
        }

        [Test]
        public async Task A_3x3_duration_matrix_and_a_3x3_distance_matrix_for_CH()
        {
            var response = await _osrmClient.GetTableAsync(ProjectOsrmOrgDocs.A_3x3_duration_matrix_and_a_3x3_distance_matrix_for_CH);

            var json = JsonSerializer.Serialize(response, OsrmHttpApiClient.DefaultJsonSerializerOptions);

            Approvals.VerifyJson(json);
        }

        [Test]
        public async Task Round_trip_in_Berlin_with_three_stops()
        {
            var response = await _osrmClient.GetTripAsync(ProjectOsrmOrgDocs.Round_trip_in_Berlin_with_three_stops);

            var json = JsonSerializer.Serialize(response, OsrmHttpApiClient.DefaultJsonSerializerOptions);

            Approvals.VerifyJson(json);
        }

        [Test]
        public async Task Round_trip_in_Berlin_with_four_stops_starting_at_the_first_stop_ending_at_the_last()
        {
            var response = await _osrmClient.GetTripAsync(ProjectOsrmOrgDocs.Round_trip_in_Berlin_with_four_stops_starting_at_the_first_stop_ending_at_the_last);

            var json = JsonSerializer.Serialize(response, OsrmHttpApiClient.DefaultJsonSerializerOptions);

            Approvals.VerifyJson(json);
        }
    }
}