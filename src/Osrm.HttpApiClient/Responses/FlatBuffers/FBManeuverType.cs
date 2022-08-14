using FlatSharp.Attributes;

namespace Osrm.HttpApiClient
{
    [FlatBufferEnum(typeof(byte))]
    public enum FBManeuverType : byte
    {
        Turn,
        NewName,
        Depart,
        Arrive,
        Merge,
        OnRamp,
        OffRamp,
        Fork,
        EndOfRoad,
        Continue,
        Roundabout,
        Rotary,
        RoundaboutTurn,
        Notification,
        ExitRoundabout,
        ExitRotary
    }
}
