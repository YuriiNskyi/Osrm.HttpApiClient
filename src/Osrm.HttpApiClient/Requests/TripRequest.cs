﻿using System.Collections.Generic;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// The trip plugin solves the Traveling Salesman Problem using a greedy heuristic (farthest-insertion algorithm) for 10 or more waypoints and uses brute force for less than 10 waypoints.
    /// The returned path does not have to be the fastest path.
    /// As TSP is NP-hard it only returns an approximation. Note that all input coordinates have to be connected for the trip service to work.
    /// </summary>
    public abstract record TripRequest<TGeometry, TFormat> : CommonGeometryRequest<TGeometry, TFormat>
        where TGeometry : Geometry
        where TFormat : struct, IFormat
    {
        private RouteAnnotations _annotations = RouteAnnotations.False;
        private Overview _overview = Overview.Simplified;
        private SourceCoordinate _source = SourceCoordinate.Any;
        private DestinationCoordinate _destination = DestinationCoordinate.Any;

        protected TripRequest(string profile, Coordinates coordinates)
            : base(profile, coordinates)
        {
        }

        /// <summary>
        /// Returned route is a roundtrip (route returns to first location).
        /// </summary>
        public bool Roundtrip { get; private set; } = true;

        /// <summary>
        /// Returned route starts at any or first coordinate.
        /// </summary>
        public SourceCoordinate Source 
        {
            get => _source;
            private set => _source = value ?? SourceCoordinate.Any;
        }

        /// <summary>
        /// Returned route ends at any or last coordinate.
        /// </summary>
        public DestinationCoordinate Destination 
        {
            get => _destination;
            private set => _destination = value ?? DestinationCoordinate.Any; 
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

        public TripRequest<TGeometry, TFormat> WithRoundTrip(
            SourceCoordinate source,
            DestinationCoordinate destination)
        {
            Roundtrip = true;
            Source = source;
            Destination = destination;

            return this;
        }

        public TripRequest<TGeometry, TFormat> WithoutRoundtrip()
        {
            Roundtrip = false;
            Source = SourceCoordinate.First;
            Destination = DestinationCoordinate.Last;

            return this;
        }

        public override string Service => "trip";

        public override IReadOnlyCollection<RequestOption> AdditionalOptions => new[]
        {
            RequestOption.Create("roundtrip", Roundtrip.ToLowerInvariant()),
            RequestOption.Create("source", Source.Value),
            RequestOption.Create("destination", Destination.Value),
            RequestOption.Create("steps", Steps.ToLowerInvariant()),
            RequestOption.Create("annotations", Annotations.Value),
            RequestOption.Create("geometries", Geometries),
            RequestOption.Create("overview", Overview.Value),
        };
    }

    public record PolylineTripRequest<TFormat> : TripRequest<PolylineGeometry, TFormat>
        where TFormat : struct, IFormat
    {
        public PolylineTripRequest(string profile, Coordinates coordinates)
            : base(profile, coordinates)
        {
        }

        public override string Geometries => PolylineGeometry.Name;
    }

    public record Polyline6TripRequest<TFormat> : TripRequest<Polyline6Geometry, TFormat>
        where TFormat : struct, IFormat
    {
        public Polyline6TripRequest(string profile, Coordinates coordinates)
            : base(profile, coordinates)
        {
        }

        public override string Geometries => Polyline6Geometry.Name;
    }

    public record GeoJsonTripRequest<TFormat> : TripRequest<GeoJsonGeometry, TFormat>
        where TFormat : struct, IFormat
    {
        public GeoJsonTripRequest(string profile, Coordinates coordinates)
            : base(profile, coordinates)
        {
        }

        public override string Geometries => GeoJsonGeometry.Name;
    }
}
