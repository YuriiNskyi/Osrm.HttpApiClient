using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Osrm.HttpApiClient
{
    [DebuggerDisplay("{Value, nq}")]
    public abstract record Coordinates
    {
        public abstract string Value { get; }

        public virtual IReadOnlyCollection<RequestOption> Options { get; } = Array.Empty<RequestOption>();
    }

    public record GeographicalCoordinates : Coordinates
    {
        public IReadOnlyCollection<Coordinate> Coordinates { get; }

        private GeographicalCoordinates(IReadOnlyCollection<Coordinate> coordinates)
        {
            Coordinates = coordinates ?? throw new ArgumentNullException(nameof(coordinates));
        }

        public override string Value
            => Coordinates
                .Select(c => $"{c.Longitude.InvariantCulture()},{c.Latitude.InvariantCulture()}")
                .Join(RequestConstants.SemiColon);

        public override IReadOnlyCollection<RequestOption> Options => new[]
        {
            Coordinates.Any(c => c.Bearing is not null) 
                ? RequestOption.Create(
                    "bearings",
                    Coordinates
                        .Select(c => c.Bearing is null 
                            ? string.Empty 
                            : $"{c.Bearing.Value.InvariantCulture()},{c.Bearing.Range.InvariantCulture()}")
                        .Join(RequestConstants.SemiColon))
                : RequestOption.Empty,

            Coordinates.Any(c => c.Radius.HasValue) 
                ? RequestOption.Create(
                    "radiuses",
                    Coordinates
                        .Select(c => c.Radius.HasValue 
                            ? c.Radius.Value.InvariantCulture() 
                            : "unlimited")
                        .Join(RequestConstants.SemiColon))
                : RequestOption.Empty,

            Coordinates.Any(c => c.Hint is not null)
                ? RequestOption.Create(
                    "hints",
                    Coordinates
                        .Select(c => string.IsNullOrWhiteSpace(c.Hint)
                            ? string.Empty
                            : c.Hint)
                        .Join(RequestConstants.SemiColon))
                : RequestOption.Empty,

            Coordinates.Any(c => c.Approach is not null) 
                ? RequestOption.Create(
                    "approaches",
                    Coordinates
                        .Select(c => c.Approach is null 
                            ? Approach.Unrestricted.Value 
                            : c.Approach.Value)
                        .Join(RequestConstants.SemiColon))
                : RequestOption.Empty,
        };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GeographicalCoordinates Create(params Coordinate[] coordinates)
            => new (coordinates);
    }

    public record PolylineCoordinates : Coordinates
    {
        public string Polyline { get; }

        private PolylineCoordinates(string polyline)
        {
            if (string.IsNullOrWhiteSpace(polyline))
            {
                throw new ArgumentNullException(nameof(polyline));
            }

            Polyline = polyline;
        }

        public override string Value => $"polyline({HttpUtility.UrlEncode(Polyline)})";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static PolylineCoordinates Create(string polyline)
            => new (polyline);
    }

    public record Polyline6Coordinates : Coordinates
    {
        public string Polyline { get; }

        private Polyline6Coordinates(string polyline)
        {
            if (string.IsNullOrWhiteSpace(polyline))
            {
                throw new ArgumentNullException(nameof(polyline));
            }

            Polyline = polyline;
        }

        public override string Value => $"polyline6({HttpUtility.UrlEncode(Polyline)})";

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Polyline6Coordinates Create(string polyline)
            => new (polyline);
    }
}
