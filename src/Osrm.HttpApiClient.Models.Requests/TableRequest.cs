using System;
using System.Collections.Generic;
using System.Linq;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Computes the duration of the fastest route between all pairs of supplied coordinates.
    /// Returns the durations or distances or both between the coordinate pairs.
    /// Note that the distances are not the shortest distance between two coordinates, but rather the distances of the fastest routes.
    /// Duration is in seconds and distances is in meters.
    /// </summary>
    public record TableRequest : CommonRequest
    {
        private IReadOnlyCollection<int> _sources = Array.Empty<int>();
        private IReadOnlyCollection<int> _destinations = Array.Empty<int>();
        private TableAnnotations _annotations = TableAnnotations.Duration;
        private FallbackCoordinate _fallbackCoordinate = FallbackCoordinate.Input;
        private double? _scaleFactor = null;
        private double? _fallbackSpeed = null;

        public TableRequest(string profile, Coordinates coordinates)
            : base(profile, coordinates)
        {
        }

        /// <summary>
        /// Use location with given index as source.
        /// </summary>
        public IReadOnlyCollection<int> Sources
        {
            get => _sources;
            set => _sources = value ?? Array.Empty<int>();
        }

        /// <summary>
        /// Use location with given index as destination.
        /// </summary>
        public IReadOnlyCollection<int> Destinations
        {
            get => _destinations;
            set => _destinations = value ?? Array.Empty<int>();
        }

        /// <summary>
        /// Return the requested table or tables in response.
        /// </summary>
        public TableAnnotations Annotations
        {
            get => _annotations;
            set => _annotations = value ?? TableAnnotations.Duration;
        }

        /// <summary>
        /// If no route found between a source/destination pair, calculate the as-the-crow-flies distance, then use this speed to estimate duration.
        /// </summary>
        public double? FallbackSpeed 
        {
            get => _fallbackSpeed;
            set => _fallbackSpeed = value is null || value > 0 ? value : null;
        }

        /// <summary>
        /// When using a fallback_speed, use the user-supplied coordinate ( input ), or the snapped location ( snapped ) for calculating distances.
        /// </summary>
        public FallbackCoordinate FallbackCoordinate
        {
            get => _fallbackCoordinate;
            set => _fallbackCoordinate = value ?? FallbackCoordinate.Input;
        }

        /// <summary>
        /// Use in conjunction with annotations=durations. Scales the table duration values by this number.
        /// </summary>
        public double? ScaleFactor 
        {
            get => _scaleFactor;
            set => _scaleFactor = value is null || value > 0 ? value : null;
        }

        public override string Service => "table";

        public override IReadOnlyCollection<RequestOption> AdditionalOptions => new[]
        {
            RequestOption.Create("sources", Sources.Any() ? Sources.Join(RequestConstants.SemiColon) : "all"),
            RequestOption.Create("destinations", Destinations.Any() ? Destinations.Join(RequestConstants.SemiColon) : "all"),
            RequestOption.Create("annotations", Annotations.Value),
            FallbackSpeed.HasValue
                ? RequestOption.Create("fallback_speed", FallbackSpeed.Value.InvariantCulture())
                : RequestOption.Empty,
            RequestOption.Create("fallback_coordinate", FallbackCoordinate.Value),
            ScaleFactor.HasValue 
                ? RequestOption.Create("scale_factor", ScaleFactor.Value.InvariantCulture())
                : RequestOption.Empty,
        };
    }
}
