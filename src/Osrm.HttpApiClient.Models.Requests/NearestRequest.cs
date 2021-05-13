using System.Collections.Generic;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Snaps a coordinate to the street network and returns the nearest n matches.
    /// </summary>
    public record NearestRequest : CommonRequest
    {
        private int _nearestSegments = 1;

        public NearestRequest(string profile, Coordinate coordinate)
            : base(profile, GeographicalCoordinates.Create(coordinate))
        {
        }

        /// <summary>
        /// Number of nearest segments that should be returned.
        /// </summary>
        public int NearestSegments 
        { 
            get => _nearestSegments;
            set => _nearestSegments = value > 0 ? value : 1;
        }

        public override string Service => "nearest";

        public override IReadOnlyCollection<RequestOption> AdditionalOptions => new[]
        {
            RequestOption.Create("number", NearestSegments.ToString()),
        };
    }
}
