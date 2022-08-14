using FlatSharp.Attributes;

namespace Osrm.HttpApiClient
{
    [FlatBufferTable]
    public class FBIntersection
    {
        [FlatBufferItem(0)]
        public virtual FBPosition? Location { get; set; }

        [FlatBufferItem(1)]
        public virtual short[]? Bearings { get; set; }

        [FlatBufferItem(2)]
        public virtual string? Classes { get; set; }

        [FlatBufferItem(3)]
        public virtual bool[]? Entry { get; set; }

        [FlatBufferItem(4)]
        public virtual uint InBearing { get; set; }

        [FlatBufferItem(5)]
        public virtual uint OutBearing { get; set; }

        [FlatBufferItem(6)]
        public virtual FBLane[]? Lanes { get; set; }
    }
}
