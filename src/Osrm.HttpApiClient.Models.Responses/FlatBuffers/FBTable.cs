using FlatSharp.Attributes;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Almost same as json Table object.
    /// The main difference is that 'sources' field is absent and root's object 'waypoints' field is used instead.
    /// The following properties differ: durations, distances, destiantions, rows, cols.
    /// </summary>
    [FlatBufferTable]
    public class FBTable
    {
        /// <summary>
        /// Flat representation of a durations matrix. Element at row;col can be adressed as [row * cols + col].
        /// </summary>
        [FlatBufferItem(0)]
        public virtual float[]? Durations { get; set; }

        /// <summary>
        /// Number of rows in durations/destinations matrices.
        /// </summary>
        [FlatBufferItem(1)]
        public virtual ushort Rows { get; set; }

        /// <summary>
        /// Number of cols in durations/destinations matrices.
        /// </summary>
        [FlatBufferItem(2)]
        public virtual ushort Cols { get; set; }

        /// <summary>
        /// Flat representation of a destinations matrix. Element at row;col can be adressed as [row * cols + col].
        /// </summary>
        [FlatBufferItem(3)]
        public virtual float[]? Distances { get; set; }

        /// <summary>
        /// Array of Waypoint objects. Will be null if skip_waypoints will be set to true.
        /// </summary>
        [FlatBufferItem(4)]
        public virtual Waypoint[]? Destinations { get; set; }

        /// <summary>
        /// Array of arrays containing i,j pairs indicating which cells contain estimated values based on fallback_speed.
        /// Will be absent if fallback_speed is not used.
        /// </summary>
        [FlatBufferItem(5)]
        public virtual uint[]? FallbackSpeedCells { get; set; }
    }
}
