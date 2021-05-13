using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    public static class OsrmServices
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MatchRequestBuilder<PolylineGeometry> PolylineMatch(string profile, Coordinates coordinates)
            => new (new PolylineMatchRequest(profile, coordinates));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MatchRequestBuilder<Polyline6Geometry> Polyline6Match(string profile, Coordinates coordinates)
            => new (new Polyline6MatchRequest(profile, coordinates));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MatchRequestBuilder<GeoJsonGeometry> GeoJsonMatch(string profile, Coordinates coordinates)
            => new (new GeoJsonMatchRequest(profile, coordinates));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static NearestRequestBuilder Nearest(string profile, Coordinate coordinate)
            => new (profile, coordinate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RouteRequestBuilder<PolylineGeometry> PolylineRoute(string profile, Coordinates coordinates)
            => new (new PolylineRouteRequest(profile, coordinates));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RouteRequestBuilder<Polyline6Geometry> Polyline6Route(string profile, Coordinates coordinates)
            => new (new Polyline6RouteRequest(profile, coordinates));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RouteRequestBuilder<GeoJsonGeometry> GeoJsonRoute(string profile, Coordinates coordinates)
            => new (new GeoJsonRouteRequest(profile, coordinates));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TableRequestBuilder Table(string profile, Coordinates coordinates)
            => new (profile, coordinates);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TripRequestBuilder<PolylineGeometry> PolylineTrip(string profile, Coordinates coordinates)
            => new (new PolylineTripRequest(profile, coordinates));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TripRequestBuilder<Polyline6Geometry> Polyline6Trip(string profile, Coordinates coordinates)
            => new (new Polyline6TripRequest(profile, coordinates));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TripRequestBuilder<GeoJsonGeometry> GeoJsonTrip(string profile, Coordinates coordinates)
            => new (new GeoJsonTripRequest(profile, coordinates));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TileRequest Tile(string profile, int x, int y, int zoom)
            => new (profile, x, y, zoom);
    }
}
