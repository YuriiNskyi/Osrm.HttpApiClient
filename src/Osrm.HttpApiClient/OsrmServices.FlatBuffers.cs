using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    public static partial class OsrmServices
    {
        public static class FlatBuffers
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static MatchRequestBuilder<PolylineGeometry, FlatBuffersFormat> PolylineMatch(string profile, Coordinates coordinates)
            => new(new PolylineMatchRequest<FlatBuffersFormat>(profile, coordinates));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static MatchRequestBuilder<Polyline6Geometry, FlatBuffersFormat> Polyline6Match(string profile, Coordinates coordinates)
                => new(new Polyline6MatchRequest<FlatBuffersFormat>(profile, coordinates));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static MatchRequestBuilder<GeoJsonGeometry, FlatBuffersFormat> GeoJsonMatch(string profile, Coordinates coordinates)
                => new(new GeoJsonMatchRequest<FlatBuffersFormat>(profile, coordinates));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static NearestRequestBuilder<FlatBuffersFormat> Nearest(string profile, Coordinate coordinate)
                => new(profile, coordinate);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RouteRequestBuilder<PolylineGeometry, FlatBuffersFormat> PolylineRoute(string profile, Coordinates coordinates)
                => new(new PolylineRouteRequest<FlatBuffersFormat>(profile, coordinates));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RouteRequestBuilder<Polyline6Geometry, FlatBuffersFormat> Polyline6Route(string profile, Coordinates coordinates)
                => new(new Polyline6RouteRequest<FlatBuffersFormat>(profile, coordinates));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static RouteRequestBuilder<GeoJsonGeometry, FlatBuffersFormat> GeoJsonRoute(string profile, Coordinates coordinates)
                => new(new GeoJsonRouteRequest<FlatBuffersFormat>(profile, coordinates));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static TableRequestBuilder<FlatBuffersFormat> Table(string profile, Coordinates coordinates)
                => new(profile, coordinates);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static TripRequestBuilder<PolylineGeometry, FlatBuffersFormat> PolylineTrip(string profile, Coordinates coordinates)
                => new(new PolylineTripRequest<FlatBuffersFormat>(profile, coordinates));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static TripRequestBuilder<Polyline6Geometry, FlatBuffersFormat> Polyline6Trip(string profile, Coordinates coordinates)
                => new(new Polyline6TripRequest<FlatBuffersFormat>(profile, coordinates));

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static TripRequestBuilder<GeoJsonGeometry, FlatBuffersFormat> GeoJsonTrip(string profile, Coordinates coordinates)
                => new(new GeoJsonTripRequest<FlatBuffersFormat>(profile, coordinates));
        }
    }
}
