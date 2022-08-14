using System;
using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    public static class SlippyMapTiles
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static double ToRadians(double angle)
            => Math.PI / 180D * angle;

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static int ToX(double longitude, int zoom)
            => (int)Math.Floor((longitude + 180D) / 360D * (1 << zoom));

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static int ToY(double latitude, int zoom)
            => (int)Math.Floor((1 - Math.Log(Math.Tan(ToRadians(latitude)) + (1 / Math.Cos(ToRadians(latitude)))) / Math.PI) / 2 * (1 << zoom));

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static double ToLongitude(int x, int zoom)
            => (x / (double)(1 << zoom) * 360D) - 180D;

        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        public static double ToLatitude(int y, int zoom)
        {
            var n = Math.PI - 2.0 * Math.PI * y / (1 << zoom);
            return 180D / Math.PI * Math.Atan(0.5 * (Math.Exp(n) - Math.Exp(-n)));
        }
    }
}
