using FlatSharp.Attributes;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Almost same as json Route object.
    /// The following properties differ: polyline, coordinates, leg.
    /// </summary>
    [FlatBufferTable]
    public class FBRouteObject
    {
        /// <summary>
        /// The distance traveled by the route, in float meters.
        /// </summary>
        [FlatBufferItem(0)]
        public virtual float Distance { get; set; }

        /// <summary>
        /// The estimated travel time, in float number of seconds.
        /// </summary>
        [FlatBufferItem(1)]
        public virtual float Duration { get; set; }

        /// <summary>
        /// The calculated weight of the route.
        /// </summary>
        [FlatBufferItem(2)]
        public virtual double Weight { get; set; }

        /// <summary>
        /// The name of the weight profile used during extraction phase.
        /// </summary>
        [FlatBufferItem(3)]
        public virtual string? WeightName { get; set; }

        /// <summary>
        /// Used only by 'Match' service.
        /// </summary>
        [FlatBufferItem(4)]
        public virtual float Confidence { get; set; }

        /// <summary>
        /// Same as json geometry.polyline or geometry.polyline6 fields.
        /// One field for both formats.
        /// </summary>
        [FlatBufferItem(5)]
        public virtual string? Polyline { get; set; }

        /// <summary>
        /// Same as json geometry.coordinates field, but different format.
        /// </summary>
        [FlatBufferItem(6)]
        public virtual FBPosition[]? Coordinates { get; set; }

        /// <summary>
        /// Array of Leg objects.
        /// </summary>
        [FlatBufferItem(7)]
        public virtual FBLeg[]? Legs { get; set; }
    }
}
