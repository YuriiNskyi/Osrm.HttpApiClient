using FlatSharp.Attributes;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Almost same as json Lane object.
    /// The following properties differ: indications.
    /// </summary>
    [FlatBufferTable]
    public class FBLane
    {
        /// <summary>
        /// Array of Turn enum values.
        /// </summary>
        [FlatBufferItem(0)]
        public virtual FBTurn[]? Indications { get; set; }

        /// <summary>
        /// A boolean flag indicating whether the lane is a valid choice in the current maneuver.
        /// </summary>
        [FlatBufferItem(1)]
        public virtual bool Valid { get; set; }
    }
}
