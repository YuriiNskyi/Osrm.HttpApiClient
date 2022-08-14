using FlatSharp.Attributes;

namespace Osrm.HttpApiClient
{
    [FlatBufferEnum(typeof(byte))]
    public enum FBTurn : byte
    {
        None,
        UTurn,
        SharpRight,
        Right,
        SlightRight,
        Straight,
        SlightLeft,
        Left,
        SharpLeft
    }
}
