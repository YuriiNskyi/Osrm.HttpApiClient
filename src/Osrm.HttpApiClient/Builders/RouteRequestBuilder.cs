using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Fluent way to build Route requests.
    /// </summary>
    /// <typeparam name="TGeometry">Geometry.</typeparam>
    public class RouteRequestBuilder<TGeometry, TFormat>
        : CommonRequestBuilder<RouteRequest<TGeometry, TFormat>, RouteRequestBuilder<TGeometry, TFormat>, TFormat>
        where TGeometry : Geometry
        where TFormat : struct, IFormat
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="request">Route request specified by Geometry.</param>
        public RouteRequestBuilder(RouteRequest<TGeometry, TFormat> request)
            : base(request)
        {
        }

        /// <summary>
        /// Returns alternatives in response.
        /// </summary>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RouteRequestBuilder<TGeometry, TFormat> Alternatives(Alternatives alternatives)
        {
            Request.Alternatives = alternatives;

            return this;
        }

        /// <summary>
        /// Returns steps in response.
        /// </summary>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RouteRequestBuilder<TGeometry, TFormat> ReturnSteps()
        {
            Request.Steps = true;

            return this;
        }

        /// <summary>
        /// Returns annotations in response.
        /// </summary>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RouteRequestBuilder<TGeometry, TFormat> Annotations(RouteAnnotations annotations)
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
        public RouteRequestBuilder<TGeometry, TFormat> Overview(Overview overview)
        {
            Request.Overview = overview;

            return this;
        }

        /// <summary>
        /// Sets continue straight parameter.
        /// </summary>
        /// <param name="continueStraight">Continue straight parameter.</param>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RouteRequestBuilder<TGeometry, TFormat> ContinueStraight(ContinueStraight continueStraight)
        {
            Request.ContinueStraight = continueStraight;

            return this;
        }

        /// <summary>
        /// Sets waypoints
        /// </summary>
        /// <param name="waypoints">Waypoints.</param>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RouteRequestBuilder<TGeometry, TFormat> Waypoints(params int[] waypoints)
        {
            Request.Waypoints = waypoints;

            return this;
        }
    }
}