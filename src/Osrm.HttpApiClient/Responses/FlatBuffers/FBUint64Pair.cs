using FlatSharp.Attributes;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// A pair of long long integers.
    /// Used only by Waypoint object.
    /// </summary>
    [FlatBufferStruct]
    public class FBUint64Pair
    {
        /// <summary>
        /// First pair value.
        /// </summary>
        [FlatBufferItem(0)]
        public ulong First { get; set; }

        /// <summary>
        /// Second pair value.
        /// </summary>
        [FlatBufferItem(1)]
        public ulong Second { get; set; }
    }
}
