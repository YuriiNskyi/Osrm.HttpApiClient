using System;
using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Fluent way to build Match requests.
    /// </summary>
    /// <typeparam name="TGeometry">Geometry.</typeparam>
    public class MatchRequestBuilder<TGeometry, TFormat>
        : CommonRequestBuilder<MatchRequest<TGeometry, TFormat>, MatchRequestBuilder<TGeometry, TFormat>, TFormat>
        where TGeometry : Geometry
        where TFormat : struct, IFormat
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="request">Match request specified by Geometry.</param>
        public MatchRequestBuilder(MatchRequest<TGeometry, TFormat> request)
            : base(request)
        {
        }

        /// <summary>
        /// Returns steps in response.
        /// </summary>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MatchRequestBuilder<TGeometry, TFormat> ReturnSteps()
        {
            Request.Steps = true;

            return this;
        }

        /// <summary>
        /// Returns annotations in response.
        /// </summary>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MatchRequestBuilder<TGeometry, TFormat> Annotations(RouteAnnotations annotations)
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
        public MatchRequestBuilder<TGeometry, TFormat> Overview(Overview overview)
        {
            Request.Overview = overview;

            return this;
        }

        /// <summary>
        /// Sets timestamps.
        /// </summary>
        /// <param name="timestamps">Timestamps.</param>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MatchRequestBuilder<TGeometry, TFormat> Timestamps(params DateTimeOffset[] timestamps)
        {
            Request.Timestamps = timestamps;

            return this;
        }

        /// <summary>
        /// Sets radiuses.
        /// </summary>
        /// <param name="radiuses">Radiuses.</param>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MatchRequestBuilder<TGeometry, TFormat> Radiuses(params double[] radiuses)
        {
            Request.Radiuses = radiuses;

            return this;
        }

        /// <summary>
        /// Sets gaps.
        /// </summary>
        /// <param name="gaps">Gaps.</param>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MatchRequestBuilder<TGeometry, TFormat> Gaps(Gaps gaps)
        {
            Request.Gaps = gaps;

            return this;
        }

        /// <summary>
        /// Sets Tide property to true.
        /// </summary>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MatchRequestBuilder<TGeometry, TFormat> IsTidy()
        {
            Request.Tidy = true;

            return this;
        }

        /// <summary>
        /// Sets waypoints.
        /// </summary>
        /// <param name="waypoints">Waypoints.</param>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MatchRequestBuilder<TGeometry, TFormat> Waypoints(params int[] waypoints)
        {
            Request.Waypoints = waypoints;

            return this;
        }
    }
}