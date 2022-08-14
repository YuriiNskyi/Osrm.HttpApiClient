using FlatSharp.Attributes;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Contains error information.
    /// </summary>
    [FlatBufferTable]
    public class FBError
    {
        /// <summary>
        /// Error code.
        /// </summary>
        [FlatBufferItem(0)]
        public virtual string? Code { get; set; }

        /// <summary>
        /// Detailed error message.
        /// </summary>
        [FlatBufferItem(1)]
        public virtual string? Message { get; set; }
    }
}
