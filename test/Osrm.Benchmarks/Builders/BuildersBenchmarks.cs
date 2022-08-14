using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using Osrm.Examples;
using Osrm.HttpApiClient;

namespace Osrm.Benchmarks
{
    [MemoryDiagnoser]
    public class BuildersBenchmarks
    {
        [Benchmark]
        public CommonRequest Full_GeoJson_route_query()
            => ProjectOsrmOrgDocs.Full_GeoJson_route_query;

        [Benchmark]
        public CommonRequest Full_Polyline_route_query()
            => ProjectOsrmOrgDocs.Full_Polyline_route_query;

        [Benchmark]
        public CommonRequest Query_on_Berlin_with_three_coordinates()
            => ProjectOsrmOrgDocs.Query_on_Berlin_with_three_coordinates;

        [Benchmark]
        public CommonRequest Query_on_Berlin_excluding_the_usage_of_motorways()
            => ProjectOsrmOrgDocs.Query_on_Berlin_excluding_the_usage_of_motorways;

        [Benchmark]
        public CommonRequest Query_on_Berlin_using_polyline()
            => ProjectOsrmOrgDocs.Query_on_Berlin_using_polyline;

        [Benchmark]
        public CommonRequest Querying_nearest_three_snapped_locations()
            => ProjectOsrmOrgDocs.Querying_nearest_three_snapped_locations;

        [Benchmark]
        public CommonRequest A_3x3_matrix()
            => ProjectOsrmOrgDocs.A_3x3_matrix;

        [Benchmark]
        public CommonRequest A_1x3_duration_matrix()
            => ProjectOsrmOrgDocs.A_1x3_duration_matrix;

        [Benchmark]
        public CommonRequest An_asymmetric_3x2_duration_matrix_with_from_the_polyline_encoded_locations()
            => ProjectOsrmOrgDocs.An_asymmetric_3x2_duration_matrix_with_from_the_polyline_encoded_locations;

        [Benchmark]
        public CommonRequest A_3x3_duration_matrix()
            => ProjectOsrmOrgDocs.A_3x3_duration_matrix;

        [Benchmark]
        public CommonRequest A_3x3_duration_matrix_for_CH()
            => ProjectOsrmOrgDocs.A_3x3_duration_matrix_for_CH;

        [Benchmark]
        public CommonRequest A_3x3_duration_matrix_and_a_3x3_distance_matrix_for_CH()
            => ProjectOsrmOrgDocs.A_3x3_duration_matrix_and_a_3x3_distance_matrix_for_CH;

        [Benchmark]
        public CommonRequest Round_trip_in_Berlin_with_three_stops()
            => ProjectOsrmOrgDocs.Round_trip_in_Berlin_with_three_stops;

        [Benchmark]
        public CommonRequest Round_trip_in_Berlin_with_four_stops_starting_at_the_first_stop_ending_at_the_last()
            => ProjectOsrmOrgDocs.Round_trip_in_Berlin_with_four_stops_starting_at_the_first_stop_ending_at_the_last;

        ////[Benchmark]
        ////public TileRequest Z_13_tile_for_downtown_San_Francisco()
        ////    => ProjectOsrmOrgDocs.Z_13_tile_for_downtown_San_Francisco;
    }
}
