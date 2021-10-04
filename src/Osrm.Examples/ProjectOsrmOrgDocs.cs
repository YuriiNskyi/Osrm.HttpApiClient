using Osrm.HttpApiClient;

namespace Osrm.Examples
{
    public static class ProjectOsrmOrgDocs
    {
        private const string Driving = "driving";

        public static RouteRequest<GeoJsonGeometry> Full_GeoJson_route_query
            => OsrmServices
                .GeoJsonRoute(
                    Driving,
                    GeographicalCoordinates.Create(
                        Coordinate.Create(13.388860, 52.517037),
                        Coordinate.Create(13.397634, 52.529407),
                        Coordinate.Create(13.428555, 52.523219)))
                .Overview(Overview.Full)
                .ReturnAlternatives()
                .ReturnAnnotations()
                .ReturnSteps()
                .Build();

        public static RouteRequest<PolylineGeometry> Full_Polyline_route_query
            => OsrmServices
                .PolylineRoute(
                    Driving,
                    GeographicalCoordinates.Create(
                        Coordinate.Create(13.388860, 52.517037),
                        Coordinate.Create(13.397634, 52.529407),
                        Coordinate.Create(13.428555, 52.523219)))
                .Overview(Overview.Full)
                .ReturnAlternatives()
                .ReturnAnnotations()
                .ReturnSteps()
                .Build();

        public static RouteRequest<GeoJsonGeometry> Query_on_Berlin_with_three_coordinates 
            => OsrmServices
                .GeoJsonRoute(
                    Driving,
                    GeographicalCoordinates.Create(
                        Coordinate.Create(13.388860, 52.517037),
                        Coordinate.Create(13.397634, 52.529407),
                        Coordinate.Create(13.428555, 52.523219)))
                .Overview(Overview.False)
                .Build();

        public static RouteRequest<GeoJsonGeometry> Query_on_Berlin_excluding_the_usage_of_motorways 
            => OsrmServices
                .GeoJsonRoute(
                    Driving,
                    GeographicalCoordinates.Create(
                        Coordinate.Create(13.388860, 52.517037),
                        Coordinate.Create(13.397634, 52.529407)))
                .Exclude(ClassName.From("motorway"))
                .Build();

        public static RouteRequest<GeoJsonGeometry> Query_on_Berlin_using_polyline 
            => OsrmServices
                .GeoJsonRoute(
                    Driving,
                    PolylineCoordinates.Create("ofp_Ik_vpAilAyu@te@g`E"))
                .Overview(Overview.False)
                .Build();

        public static NearestRequest Querying_nearest_three_snapped_locations 
            => OsrmServices
                .Nearest(
                    Driving,
                    Coordinate.Create(13.388860, 52.517037, Bearing.Create(0, 20)))
                .NearestSegments(3)
                .Build();

        public static TableRequest A_3x3_matrix 
            => OsrmServices
                .Table(
                    Driving,
                    GeographicalCoordinates.Create(
                        Coordinate.Create(13.388860, 52.517037),
                        Coordinate.Create(13.397634, 52.529407),
                        Coordinate.Create(13.428555, 52.523219)))
                .Build();

        public static TableRequest A_1x3_duration_matrix 
            => OsrmServices
                .Table(
                    Driving,
                    GeographicalCoordinates.Create(
                        Coordinate.Create(13.388860, 52.517037),
                        Coordinate.Create(13.397634, 52.529407),
                        Coordinate.Create(13.428555, 52.523219)))
                .Sources(0)
                .Build();

        public static TableRequest An_asymmetric_3x2_duration_matrix_with_from_the_polyline_encoded_locations 
            => OsrmServices
                .Table(
                    Driving,
                    PolylineCoordinates.Create("egs_Iq_aqAppHzbHulFzeMe`EuvKpnCglA"))
                .Sources(0, 1, 3)
                .Destinations(2, 4)
                .Build();

        public static TableRequest A_3x3_duration_matrix 
            => OsrmServices
                .Table(
                    Driving,
                    GeographicalCoordinates.Create(
                        Coordinate.Create(13.388860, 52.517037),
                        Coordinate.Create(13.397634, 52.529407),
                        Coordinate.Create(13.428555, 52.523219)))
                .Annotations(Annotations.Duration)
                .Build();

        public static TableRequest A_3x3_duration_matrix_for_CH 
            => OsrmServices
                .Table(
                    Driving,
                    GeographicalCoordinates.Create(
                        Coordinate.Create(13.388860, 52.517037),
                        Coordinate.Create(13.397634, 52.529407),
                        Coordinate.Create(13.428555, 52.523219)))
                .Annotations(Annotations.Distance)
                .Build();

        public static TableRequest A_3x3_duration_matrix_and_a_3x3_distance_matrix_for_CH 
            => OsrmServices
                .Table(
                    Driving,
                    GeographicalCoordinates.Create(
                        Coordinate.Create(13.388860, 52.517037),
                        Coordinate.Create(13.397634, 52.529407),
                        Coordinate.Create(13.428555, 52.523219)))
                .Annotations(Annotations.DurationAndDistance)
                .Build();

        public static TripRequest<GeoJsonGeometry> Round_trip_in_Berlin_with_three_stops 
            => OsrmServices
                .GeoJsonTrip(
                    Driving,
                    GeographicalCoordinates.Create(
                        Coordinate.Create(13.388860, 52.517037),
                        Coordinate.Create(13.397634, 52.529407),
                        Coordinate.Create(13.428555, 52.523219)))
                .Build();

        public static TripRequest<GeoJsonGeometry> Round_trip_in_Berlin_with_four_stops_starting_at_the_first_stop_ending_at_the_last 
            => OsrmServices
                .GeoJsonTrip(
                    Driving,
                    GeographicalCoordinates.Create(
                        Coordinate.Create(13.388860, 52.517037),
                        Coordinate.Create(13.397634, 52.529407),
                        Coordinate.Create(13.428555, 52.523219),
                        Coordinate.Create(13.418555, 52.523215)))
                .WithRoundTrip(
                    SourceCoordinate.First,
                    DestinationCoordinate.Last)
                .Build();

        public static TileRequest Z_13_tile_for_downtown_San_Francisco
            => OsrmServices
                .Tile(
                    Driving,
                    x: 1310,
                    y: 3166,
                    zoom: 13);

        public static RouteRequest<GeoJsonGeometry>[] GeoJsonRoutes => new RouteRequest<GeoJsonGeometry>[]
        {
            Full_GeoJson_route_query,
            Query_on_Berlin_with_three_coordinates,
            Query_on_Berlin_excluding_the_usage_of_motorways,
            Query_on_Berlin_using_polyline,
        };

        public static RouteRequest<PolylineGeometry>[] PolylineRoutes => new RouteRequest<PolylineGeometry>[]
        {
            Full_Polyline_route_query,
        };

        public static NearestRequest[] Nearests => new NearestRequest[]
        {
            Querying_nearest_three_snapped_locations,
        };

        public static TableRequest[] Tables => new TableRequest[]
        {
            A_3x3_matrix,
            A_1x3_duration_matrix,
            An_asymmetric_3x2_duration_matrix_with_from_the_polyline_encoded_locations,
            A_3x3_duration_matrix,
            A_3x3_duration_matrix_for_CH,
            A_3x3_duration_matrix_and_a_3x3_distance_matrix_for_CH,
        };

        public static TripRequest<GeoJsonGeometry>[] Trips => new TripRequest<GeoJsonGeometry>[]
        {
            Round_trip_in_Berlin_with_three_stops,
            Round_trip_in_Berlin_with_four_stops_starting_at_the_first_stop_ending_at_the_last,
        };

        public static CommonRequest[] All => new CommonRequest[]
        {
            Full_GeoJson_route_query,
            Full_Polyline_route_query,
            Query_on_Berlin_with_three_coordinates,
            Query_on_Berlin_excluding_the_usage_of_motorways,
            Query_on_Berlin_using_polyline,
            Querying_nearest_three_snapped_locations,
            A_3x3_matrix,
            A_1x3_duration_matrix,
            An_asymmetric_3x2_duration_matrix_with_from_the_polyline_encoded_locations,
            A_3x3_duration_matrix,
            A_3x3_duration_matrix_for_CH,
            A_3x3_duration_matrix_and_a_3x3_distance_matrix_for_CH,
            Round_trip_in_Berlin_with_three_stops,
            Round_trip_in_Berlin_with_four_stops_starting_at_the_first_stop_ending_at_the_last,
        };
    }
}
