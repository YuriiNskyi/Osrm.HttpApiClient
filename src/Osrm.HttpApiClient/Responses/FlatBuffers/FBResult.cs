using FlatSharp.Attributes;

namespace Osrm.HttpApiClient
{
    [FlatBufferTable]
    public class FBResult
    {
        /// <summary>
        /// Marks response as erroneous.
        /// Erroneus response should include code field set, all the other field may not present.
        /// </summary>
        [FlatBufferItem(0)]
        public virtual bool Error { get; set; }

        /// <summary>
        /// Error description object, only present, when error is true.
        /// </summary>
        [FlatBufferItem(1)]
        public virtual FBError? Code { get; set; }

        [FlatBufferItem(2)]
        public virtual string? DataVersion { get; set; }

        /// <summary>
        /// Used as 'sources' waypoints for a 'Table' service.
        /// Array of Waypoint objects.
        /// Should present for every service call, unless skip_waypoints is set to true.
        /// Table service will put sources array here.
        /// </summary>
        [FlatBufferItem(3)]
        public virtual FBWaypoint[]? Waypoints { get; set; }

        /// <summary>
        /// Array of RouteObject objects.
        /// May be empty or absent.
        /// Should present for Route/Trip/Match services call.
        /// </summary>
        [FlatBufferItem(4)]
        public virtual FBRouteObject[]? Routes { get; set; }

        /// <summary>
        /// Table object, may absent.
        /// Should be present in case of Table service call.
        /// </summary>
        [FlatBufferItem(5)]
        public virtual FBTable? Table { get; set; }
    }
}
