using System;
using System.Collections.Generic;
using System.Linq;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Map matching matches/snaps given GPS points to the road network in the most plausible way.
    /// Please note the request might result multiple sub-traces.
    /// Large jumps in the timestamps (> 60s) or improbable transitions lead to trace splits if a complete matching could not be found.
    /// The algorithm might not be able to match all points.
    /// Outliers are removed if they can not be matched successfully.
    /// </summary>
    public abstract record MatchRequest<TGeometry, TFormat> : CommonGeometryRequest<TGeometry, TFormat>
        where TGeometry : Geometry
        where TFormat : struct, IFormat
    {
        private RouteAnnotations _annotations = RouteAnnotations.False;
        private Overview _overview = Overview.Simplified;
        private IReadOnlyCollection<DateTimeOffset> _timestamps = Array.Empty<DateTimeOffset>();
        private IReadOnlyCollection<double> _radiuses = Array.Empty<double>();
        private Gaps _gaps = Gaps.Split;
        private IReadOnlyCollection<int> _waypoints = Array.Empty<int>();

        protected MatchRequest(string profile, Coordinates coordinates)
            : base(profile, coordinates)
        {
        }

        /// <summary>
        /// Return route steps for each route leg.
        /// </summary>
        public bool Steps { get; set; }

        /// <summary>
        /// Returns additional metadata for each coordinate along the route geometry.
        /// </summary>
        public RouteAnnotations Annotations 
        {
            get => _annotations;
            set => _annotations = value ?? RouteAnnotations.False;
        }

        /// <summary>
        /// Add overview geometry either full, simplified according to highest zoom level it could be display on, or not at all.
        /// </summary>
        public Overview Overview
        {
            get => _overview;
            set => _overview = value ?? Overview.Simplified;
        }
        /// <summary>
        /// Timestamps for the input locations in seconds since UNIX epoch. Timestamps need to be monotonically increasing.
        /// </summary>
        public IReadOnlyCollection<DateTimeOffset> Timestamps
        {
            get => _timestamps;
            set => _timestamps = value ?? Array.Empty<DateTimeOffset>();
        }

        /// <summary>
        /// Standard deviation of GPS precision used for map matching. If applicable use GPS accuracy.
        /// </summary>
        public IReadOnlyCollection<double> Radiuses
        {
            get => _radiuses;
            set => _radiuses = value ?? Array.Empty<double>();
        }
        /// <summary>
        /// Allows the input track splitting based on huge timestamp gaps between points.
        /// </summary>
        public Gaps Gaps
        {
            get => _gaps;
            set => _gaps = value ?? Gaps.Split;
        }

        /// <summary>
        /// Allows the input track modification to obtain better matching quality for noisy tracks.
        /// </summary>
        public bool Tidy { get; set; } = false;

        /// <summary>
        /// Treats input coordinates indicated by given indices as waypoints in returned Match object. Default is to treat all input coordinates as waypoints.
        /// </summary>
        public IReadOnlyCollection<int> Waypoints 
        {
            get => _waypoints;
            set => _waypoints = value ?? Array.Empty<int>();
        }
        public override string Service => "match";

        public override IReadOnlyCollection<RequestOption> AdditionalOptions => new[]
        {
            RequestOption.Create("steps", Steps.ToLowerInvariant()),
            RequestOption.Create("annotations", Annotations.Value),
            RequestOption.Create("geometries", Geometries),
            RequestOption.Create("overview", Overview.Value),
            Timestamps.Any()
                ? RequestOption.Create("timestamps", Timestamps.Select(t => t.ToUnixTimeSeconds()).Join(RequestConstants.SemiColon))
                : RequestOption.Empty,
            Radiuses.Any()
                ? RequestOption.Create("radiuses", Radiuses.Select(x => x.InvariantCulture()).Join(RequestConstants.SemiColon))
                : RequestOption.Empty,
            RequestOption.Create("gaps", Gaps.Value),
            RequestOption.Create("tidy", Tidy.ToLowerInvariant()),
            Waypoints.Any() 
                ? RequestOption.Create("waypoints", Waypoints.Join(RequestConstants.SemiColon)) 
                : RequestOption.Empty,
        };
    }

    public record PolylineMatchRequest<TFormat> : MatchRequest<PolylineGeometry, TFormat>
        where TFormat : struct, IFormat
    {
        public PolylineMatchRequest(string profile, Coordinates coordinates)
            : base(profile, coordinates)
        {
        }

        public override string Geometries => PolylineGeometry.Name;
    }

    public record Polyline6MatchRequest<TFormat> : MatchRequest<Polyline6Geometry, TFormat>
        where TFormat : struct, IFormat
    {
        public Polyline6MatchRequest(string profile, Coordinates coordinates)
            : base(profile, coordinates)
        {
        }

        public override string Geometries => Polyline6Geometry.Name;
    }

    public record GeoJsonMatchRequest<TFormat> : MatchRequest<GeoJsonGeometry, TFormat>
        where TFormat : struct, IFormat
    {
        public GeoJsonMatchRequest(string profile, Coordinates coordinates)
            : base(profile, coordinates)
        {
        }

        public override string Geometries => GeoJsonGeometry.Name;
    }
}
