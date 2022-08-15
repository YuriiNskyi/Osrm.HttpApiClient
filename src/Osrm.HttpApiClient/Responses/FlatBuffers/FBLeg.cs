using FlatSharp.Attributes;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Almost same as json Leg object.
    /// The following properties differ: annotations, steps.
    /// </summary>
    [FlatBufferTable]
    public class FBLeg
    {
        /// <summary>
        /// The distance traveled by this route leg, in float meters.
        /// </summary>
        [FlatBufferItem(0)]
        public virtual double Distance { get; set; }

        /// <summary>
        /// The estimated travel time, in float number of seconds.
        /// </summary>
        [FlatBufferItem(1)]
        public virtual double Duration { get; set; }

        /// <summary>
        /// The calculated weight of the route leg.
        /// </summary>
        [FlatBufferItem(2)]
        public virtual double Weight { get; set; }

        /// <summary>
        /// Summary of the route taken as string. Depends on the summary parameter: true or false.
        /// </summary>
        [FlatBufferItem(3)]
        public virtual string? Summary { get; set; }

        /// <summary>
        /// Same as json annotation field, but different format.
        /// </summary>
        [FlatBufferItem(4)]
        public virtual FBAnnotation? Annotations { get; set; }

        /// <summary>
        /// Same as step annotation field, but different format.
        /// </summary>
        [FlatBufferItem(5)]
        public virtual FBStep[]? Steps { get; set; }
    }
}
