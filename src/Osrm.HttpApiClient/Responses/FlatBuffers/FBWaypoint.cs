using FlatSharp.Attributes;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Almost same as json Waypoint object.
    /// The following properties differ: location, nodes.
    /// </summary>
    [FlatBufferTable]
    public class FBWaypoint
    {
        /// <summary>
        /// Unique internal identifier of the segment (ephemeral, not constant over data updates).
        /// This can be used on subsequent request to significantly speed up the query and to connect multiple services.
        /// E.g. you can use the hint value obtained by the nearest query as hint values for route inputs.
        /// </summary>
        [FlatBufferItem(0)]
        public virtual string? Hint { get; set; }

        /// <summary>
        /// The distance, in metres, from the input coordinate to the snapped coordinate.
        /// </summary>
        [FlatBufferItem(1)]
        public virtual float Distance { get; set; }

        /// <summary>
        /// Name of the street the coordinate snapped to.
        /// </summary>
        [FlatBufferItem(2)]
        public virtual string? Name { get; set; }

        /// <summary>
        /// Same as json location field, but different format.
        /// </summary>
        [FlatBufferItem(3)]
        public virtual FBPosition? Location { get; set; }

        /// <summary>
        /// Used only by 'Nearest' service.
        /// Same as json nodes field, but different format.
        /// </summary>
        [FlatBufferItem(4)]
        public virtual FBUint64Pair? Nodes { get; set; }

        /// <summary>
        /// Used only by 'Match' service.
        /// </summary>
        [FlatBufferItem(5)]
        public virtual uint MatchingsIndex { get; set; }

        /// <summary>
        /// Used by 'Match' and 'Trip' services.
        /// </summary>
        [FlatBufferItem(6)]
        public virtual uint WaypointIndex { get; set; }

        /// <summary>
        /// Used only by 'Match' service.
        /// </summary>
        [FlatBufferItem(7)]
        public virtual uint AlternativesCount { get; set; }

        /// <summary>
        /// Used only by 'Trip' service.
        /// </summary>
        [FlatBufferItem(8)]
        public virtual uint TripsIndex { get; set; }
    }
}
