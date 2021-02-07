using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    [DebuggerDisplay("{DebuggerDisplay, nq}")]
    public record Coordinate
    {
        public double Longitude { get; }
        public double Latitude { get; }
        public Bearing? Bearing { get; }
        public double? Radius { get; }
        public string? Hint { get; }
        public Approach? Approach { get; }

        private Coordinate(
            double longitude,
            double latitude,
            Bearing? bearing,
            double? radius,
            string? hint,
            Approach? approach)
        {
            Longitude = longitude;
            Latitude = latitude;
            Bearing = bearing;
            Radius = radius;
            Hint = hint;
            Approach = approach;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Coordinate Create(
            double longitude,
            double latitude,
            Bearing? bearing = null,
            double? radius = null,
            string? hint = null,
            Approach? approach = null)
            => new (
                longitude,
                latitude,
                bearing,
                radius,
                hint,
                approach);

        private string DebuggerDisplay 
            => $"{Longitude.InvariantCulture()}, {Latitude.InvariantCulture()}; {Bearing?.Value}° +- {Bearing?.Range}, {Radius}m. {Approach?.Value}.";
    }
}
