using FlatSharp.Attributes;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// A point on Earth.
    /// </summary>
    [FlatBufferStruct]
    public class FBPosition
    {
        /// <summary>
        /// Point's longitude. [-180, 180].
        /// </summary>
        [FlatBufferItem(0)]
        public virtual float Longitude { get; set; }

        /// <summary>
        /// Point's latitude. [-90, 90].
        /// </summary>
        [FlatBufferItem(1)]
        public virtual float Latitude { get; set; }
    }
}
