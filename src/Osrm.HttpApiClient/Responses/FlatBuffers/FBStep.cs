using FlatSharp.Attributes;

namespace Osrm.HttpApiClient
{
    [FlatBufferTable]
    public class FBStep
    {
        [FlatBufferItem(0)]
        public virtual float Distance { get; set; }

        [FlatBufferItem(1)]
        public virtual float Duratiion { get; set; }

        [FlatBufferItem(2)]
        public virtual string? Polyline { get; set; }

        [FlatBufferItem(3)]
        public virtual FBPosition[]? Coordinates { get; set; }

        [FlatBufferItem(4)]
        public virtual float Weight{ get; set; }

        [FlatBufferItem(5)]
        public virtual string? Name { get; set; }

        [FlatBufferItem(6)]
        public virtual string? Ref { get; set; }

        [FlatBufferItem(7)]
        public virtual string? Pronunciation { get; set; }

        [FlatBufferItem(8)]
        public virtual string? Destinations { get; set; }

        [FlatBufferItem(9)]
        public virtual string? Exits { get; set; }

        [FlatBufferItem(10)]
        public virtual string? Mode { get; set; }

        [FlatBufferItem(11)]
        public virtual FBStepManeuver? Maneuver { get; set; }

        [FlatBufferItem(12)]
        public virtual FBIntersection[]? Intersections { get; set; }

        [FlatBufferItem(13)]
        public virtual string? RotaryName { get; set; }

        [FlatBufferItem(14)]
        public virtual string? RotaryPronunciation { get; set; }

        /// <summary>
        /// Where true stands for the left side.
        /// </summary>
        [FlatBufferItem(15)]
        public virtual bool DrivingSide { get; set; }
    }
}
