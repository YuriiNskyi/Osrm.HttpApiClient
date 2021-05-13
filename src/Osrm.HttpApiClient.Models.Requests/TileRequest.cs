namespace Osrm.HttpApiClient
{
    /// <summary>
    /// This service generates Mapbox Vector Tiles that can be viewed with a vector-tile capable slippy-map viewer.
    /// The tiles contain road geometries and metadata that can be used to examine the routing graph.
    /// The tiles are generated directly from the data in-memory, so are in sync with actual routing results, and let you examine which roads are actually routable, and what weights they have applied.
    /// The x, y, and zoom values are the same as described at https://wiki.openstreetmap.org/wiki/Slippy_map_tilenames, and are supported by vector tile viewers like Mapbox GL JS.
    /// The response object is either a binary encoded blob with a Content-Type of application/x-protobuf, or a 404 error.
    /// Note that OSRM is hard-coded to only return tiles from zoom level 12 and higher(to avoid accidentally returning extremely large vector tiles).
    /// </summary>
    public record TileRequest : IOsrmRequest
    {
        public TileRequest(
            string profile,
            int x,
            int y,
            int zoom)
        {
            Profile = profile;
            X = x;
            Y = y;
            Zoom = zoom;
        }

        /// <summary>
        /// One of the following values: route, nearest, table, match, trip, tile.
        /// </summary>
        public string Service => "tile";

        /// <summary>
        /// Version of the protocol implemented by the service. v1 for all OSRM 5.x installations
        /// </summary>
        public string Version => "v1";

        /// <summary>
        /// Mode of transportation, is determined statically by the Lua profile that is used to prepare the data using osrm-extract.
        /// Typically car, bike or foot if using one of the supplied profiles.
        /// </summary>
        public string Profile { get; } = PredefinedProfiles.Car;

        /// <summary>
        /// X goes from 0 (left edge is 180 °W) to 2^zoom − 1 (right edge is 180 °E)
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Y goes from 0 (top edge is 85.0511 °N) to 2^zoom − 1 (bottom edge is 85.0511 °S) in a Mercator projection
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// The zoom parameter is an integer between 0 (zoomed out) and 18 (zoomed in). 18 is normally the maximum, but some tile servers might go beyond that.
        /// </summary>
        public int Zoom { get; }

        public string Uri => $"{Service}/{Version}/{Profile}/tile({X},{Y},{Zoom}).mvt";
    }
}
