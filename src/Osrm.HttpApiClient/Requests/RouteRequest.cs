﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Finds the fastest route between coordinates in the supplied order.
    /// </summary>
    public abstract record RouteRequest<TGeometry, TFormat> : CommonGeometryRequest<TGeometry, TFormat>
        where TGeometry : Geometry
        where TFormat : struct, IFormat
    {
        private Alternatives _alternatives = Alternatives.False;
        private RouteAnnotations _annotations = RouteAnnotations.False;
        private Overview _overview = Overview.Simplified;
        private ContinueStraight _continueStraight = ContinueStraight.Default;
        private IReadOnlyCollection<int> _waypoints = Array.Empty<int>();

        protected RouteRequest(string profile, Coordinates coordinates)
            : base(profile, coordinates)
        {
        }

        /// <summary>
        /// Search for alternative routes.
        /// Passing a number alternatives= n searches for up to n alternative routes.
        /// </summary>
        public Alternatives Alternatives 
        {
            get => _alternatives;
            set => _alternatives = value ?? Alternatives.False;
        }

        /// <summary>
        /// Return route steps for each route leg.
        /// </summary>
        public bool Steps { get; set; } = false;

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
        /// Forces the route to keep going straight at waypoints constraining uturns there even if it would be faster. Default value depends on the profile.
        /// </summary>
        public ContinueStraight ContinueStraight 
        {
            get => _continueStraight;
            set => _continueStraight = value ?? ContinueStraight.Default;
        }

        /// <summary>
        /// Treats input coordinates indicated by given indices as waypoints in returned Match object. Default is to treat all input coordinates as waypoints.
        /// </summary>
        public IReadOnlyCollection<int> Waypoints 
        {
            get => _waypoints;
            set => _waypoints = value ?? Array.Empty<int>();
        }

        public override string Service => "route";

        public override IReadOnlyCollection<RequestOption> AdditionalOptions => new[]
        {
            RequestOption.Create("alternatives", Alternatives.Value),
            RequestOption.Create("steps", Steps.ToLowerInvariant()),
            RequestOption.Create("annotations", Annotations.Value),
            RequestOption.Create("geometries", Geometries),
            RequestOption.Create("overview", Overview.Value),
            RequestOption.Create("continue_straight", ContinueStraight.Value),
            Waypoints.Any() 
                ? RequestOption.Create("waypoints", Waypoints.Join(RequestConstants.SemiColon))
                : RequestOption.Empty,
        };
    }

    public record PolylineRouteRequest<TFormat> : RouteRequest<PolylineGeometry, TFormat>
        where TFormat : struct, IFormat
    {
        public PolylineRouteRequest(string profile, Coordinates coordinates)
            : base(profile, coordinates)
        {
        }

        public override string Geometries => PolylineGeometry.Name;
    }

    public record Polyline6RouteRequest<TFormat> : RouteRequest<Polyline6Geometry, TFormat>
        where TFormat : struct, IFormat
    {
        public Polyline6RouteRequest(string profile, Coordinates coordinates)
            : base(profile, coordinates)
        {
        }

        public override string Geometries => Polyline6Geometry.Name;
    }

    public record GeoJsonRouteRequest<TFormat> : RouteRequest<GeoJsonGeometry, TFormat>
        where TFormat : struct, IFormat
    {
        public GeoJsonRouteRequest(string profile, Coordinates coordinates)
            : base(profile, coordinates)
        {
        }

        public override string Geometries => GeoJsonGeometry.Name;
    }
}
