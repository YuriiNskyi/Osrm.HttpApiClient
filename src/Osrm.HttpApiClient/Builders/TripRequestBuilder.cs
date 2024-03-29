﻿using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Fluent way to build Trip requests.
    /// </summary>
    /// <typeparam name="TGeometry">Geometry.</typeparam>
    public class TripRequestBuilder<TGeometry, TFormat>
        : CommonRequestBuilder<TripRequest<TGeometry, TFormat>, TripRequestBuilder<TGeometry, TFormat>, TFormat>
        where TGeometry : Geometry
        where TFormat : struct, IFormat
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="request">Trip request specified by Geometry.</param>
        public TripRequestBuilder(TripRequest<TGeometry, TFormat> request)
            : base(request)
        {
        }

        /// <summary>
        /// Returns steps in response.
        /// </summary>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TripRequestBuilder<TGeometry, TFormat> ReturnSteps()
        {
            Request.Steps = true;

            return this;
        }

        /// <summary>
        /// Returns annotations in response.
        /// </summary>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TripRequestBuilder<TGeometry, TFormat> Annotations(RouteAnnotations annotations)
        {
            Request.Annotations = annotations;

            return this;
        }

        /// <summary>
        /// Sets overview.
        /// </summary>
        /// <param name="overview">Overview.</param>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TripRequestBuilder<TGeometry, TFormat> Overview(Overview overview)
        {
            Request.Overview = overview;

            return this;
        }

        /// <summary>
        /// Returned route is a roundtrip (route returns to first location)
        /// </summary>
        /// <param name="source">Source.</param>
        /// <param name="destination">Destination.</param>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TripRequestBuilder<TGeometry, TFormat> WithRoundTrip(
            SourceCoordinate source,
            DestinationCoordinate destination)
        {
            Request.WithRoundTrip(source, destination);

            return this;
        }

        /// <summary>
        /// Returned route is NOT a roundtrip (route returns to first location)
        /// </summary>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TripRequestBuilder<TGeometry, TFormat> WithoutRoundtrip()
        {
            Request.WithoutRoundtrip();

            return this;
        }
    }
}