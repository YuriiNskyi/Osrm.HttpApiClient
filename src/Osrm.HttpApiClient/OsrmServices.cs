using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    public static partial class OsrmServices
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MatchRequestBuilder<PolylineGeometry, JsonFormat> PolylineMatch(string profile, Coordinates coordinates)
            => new (new PolylineMatchRequest<JsonFormat>(profile, coordinates));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MatchRequestBuilder<Polyline6Geometry, JsonFormat> Polyline6Match(string profile, Coordinates coordinates)
            => new (new Polyline6MatchRequest<JsonFormat>(profile, coordinates));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MatchRequestBuilder<GeoJsonGeometry, JsonFormat> GeoJsonMatch(string profile, Coordinates coordinates)
            => new (new GeoJsonMatchRequest<JsonFormat>(profile, coordinates));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static NearestRequestBuilder<JsonFormat> Nearest(string profile, Coordinate coordinate)
            => new (profile, coordinate);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RouteRequestBuilder<PolylineGeometry, JsonFormat> PolylineRoute(string profile, Coordinates coordinates)
            => new (new PolylineRouteRequest<JsonFormat>(profile, coordinates));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RouteRequestBuilder<Polyline6Geometry, JsonFormat> Polyline6Route(string profile, Coordinates coordinates)
            => new (new Polyline6RouteRequest<JsonFormat>(profile, coordinates));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RouteRequestBuilder<GeoJsonGeometry, JsonFormat> GeoJsonRoute(string profile, Coordinates coordinates)
            => new (new GeoJsonRouteRequest<JsonFormat>(profile, coordinates));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TableRequestBuilder<JsonFormat> Table(string profile, Coordinates coordinates)
            => new (profile, coordinates);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TripRequestBuilder<PolylineGeometry, JsonFormat> PolylineTrip(string profile, Coordinates coordinates)
            => new (new PolylineTripRequest<JsonFormat>(profile, coordinates));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TripRequestBuilder<Polyline6Geometry, JsonFormat> Polyline6Trip(string profile, Coordinates coordinates)
            => new (new Polyline6TripRequest<JsonFormat>(profile, coordinates));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TripRequestBuilder<GeoJsonGeometry, JsonFormat> GeoJsonTrip(string profile, Coordinates coordinates)
            => new (new GeoJsonTripRequest<JsonFormat>(profile, coordinates));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TileRequest Tile(string profile, int x, int y, int zoom)
            => new (profile, x, y, zoom);
    }
}
