using FlatSharp.Attributes;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Metadata related to other annotations.
    /// </summary>
    [FlatBufferTable]
    public class FBMetadata
    {
        /// <summary>
        /// The names of the datasources used for the speed between each pair of coordinates.
        /// lua profile is the default profile, other values arethe filenames supplied via --segment-speed-file to osrm-contract or osrm-customize.
        /// </summary>
        [FlatBufferItem(0)]
        public virtual string[]? DataSourceNames { get; set; }
    }
}
