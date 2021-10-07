using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Fluent way to build Route requests.
    /// </summary>
    /// <typeparam name="TGeometry">Geometry.</typeparam>
    public class RouteRequestBuilder<TGeometry> : CommonRequestBuilder<RouteRequest<TGeometry>, RouteRequestBuilder<TGeometry>>
        where TGeometry : Geometry
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="request">Route request specified by Geometry.</param>
        public RouteRequestBuilder(RouteRequest<TGeometry> request)
            : base(request)
        {
        }

        /// <summary>
        /// Returns alternatives in response.
        /// </summary>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RouteRequestBuilder<TGeometry> Alternatives(Alternatives alternatives)
        {
            Request.Alternatives = alternatives;

            return this;
        }

        /// <summary>
        /// Returns steps in response.
        /// </summary>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RouteRequestBuilder<TGeometry> ReturnSteps()
        {
            Request.Steps = true;

            return this;
        }

        /// <summary>
        /// Returns annotations in response.
        /// </summary>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RouteRequestBuilder<TGeometry> Annotations(RouteAnnotations annotations)
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
        public RouteRequestBuilder<TGeometry> Overview(Overview overview)
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
        public RouteRequestBuilder<TGeometry> ContinueStraight(ContinueStraight continueStraight)
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
        public RouteRequestBuilder<TGeometry> Waypoints(params int[] waypoints)
        {
            Request.Waypoints = waypoints;

            return this;
        }
    }
}