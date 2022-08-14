using FlatSharp.Attributes;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Almost same as json StepManeuver object.
    /// The following properties differ: location, type, modifier.
    /// </summary>
    [FlatBufferTable]
    public class FBStepManeuver
    {
        /// <summary>
        /// Same as json location property, but in different format.
        /// </summary>
        [FlatBufferItem(0)]
        public virtual FBPosition? Location { get; set; }

        /// <summary>
        /// The clockwise angle from true north to the direction of travel immediately before the maneuver.
        /// Range 0-359.
        /// </summary>
        [FlatBufferItem(1)]
        public virtual ushort BearingBefore { get; set; }

        /// <summary>
        /// The clockwise angle from true north to the direction of travel immediately after the maneuver.
        /// Range 0-359.
        /// </summary>
        [FlatBufferItem(2)]
        public virtual ushort BearingAfter { get; set; }

        /// <summary>
        /// Type of a maneuver (enum).
        /// </summary>
        [FlatBufferItem(3)]
        public virtual FBManeuverType Type { get; set; }

        /// <summary>
        /// Maneuver turn (enum).
        /// </summary>
        [FlatBufferItem(4)]
        public virtual FBTurn Modifier { get; set; }

        /// <summary>
        /// An optional integer indicating number of the exit to take.
        /// The property exists for the roundabout / rotary property: Number of the roundabout exit to take.
        /// If exit is undefined the destination is on the roundabout.
        /// </summary>
        [FlatBufferItem(5)]
        public virtual byte Exit { get; set; }
    }
}
