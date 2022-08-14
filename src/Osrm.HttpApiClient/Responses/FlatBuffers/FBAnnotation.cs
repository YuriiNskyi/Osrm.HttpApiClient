using FlatSharp.Attributes;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Exactly same as json annotation object.
    /// </summary>
    [FlatBufferTable]
    public class FBAnnotation
    {
        /// <summary>
        /// The distance, in metres, between each pair of coordinates.
        /// </summary>
        [FlatBufferItem(0)]
        public virtual uint[]? Distance { get; set; }

        /// <summary>
        /// The duration between each pair of coordinates, in seconds. Does not include the duration of any turns.
        /// </summary>
        [FlatBufferItem(1)]
        public virtual uint[]? Duration { get; set; }

        /// <summary>
        /// The index of the datasource for the speed between each pair of coordinates.
        /// 0 is the default profile, other values are supplied via --segment-speed-file to osrm-contract or osrm-customize.
        /// String-like names are in the metadata.datasource_names array.
        /// </summary>
        [FlatBufferItem(2)]
        public virtual uint[]? DataSources { get; set; }

        /// <summary>
        /// The OSM node ID for each coordinate along the route, excluding the first/last user-supplied coordinates.
        /// </summary>
        [FlatBufferItem(3)]
        public virtual uint[]? Nodes { get; set; }

        /// <summary>
        /// The weights between each pair of coordinates. Does not include any turn costs.
        /// </summary>
        [FlatBufferItem(4)]
        public virtual uint[]? Weight { get; set; }

        /// <summary>
        /// Convenience field, calculation of distance / duration rounded to one decimal place.
        /// </summary>
        [FlatBufferItem(5)]
        public virtual float[]? Speed { get; set; }

        /// <summary>
        /// Metadata related to other annotations.
        /// </summary>
        [FlatBufferItem(6)]
        public virtual FBMetadata? Metadata { get; set; }
    }
}
