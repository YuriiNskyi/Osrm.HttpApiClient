﻿using System;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Fluent way to build Match requests.
    /// </summary>
    /// <typeparam name="TGeometry">Geometry.</typeparam>
    public class MatchRequestBuilder<TGeometry> : CommonRequestBuilder<MatchRequest<TGeometry>, MatchRequestBuilder<TGeometry>>
        where TGeometry : Geometry
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="request">Match request specified by Geometry.</param>
        public MatchRequestBuilder(MatchRequest<TGeometry> request)
            : base(request)
        {
        }

        /// <summary>
        /// Returns steps in response.
        /// </summary>
        /// <returns>Current builder.</returns>
        public MatchRequestBuilder<TGeometry> ReturnSteps()
        {
            Request.Steps = true;

            return this;
        }

        /// <summary>
        /// Returns annotations in response.
        /// </summary>
        /// <returns>Current builder.</returns>
        public MatchRequestBuilder<TGeometry> ReturnAnnotations()
        {
            Request.Annotations = true;

            return this;
        }

        /// <summary>
        /// Sets overview.
        /// </summary>
        /// <param name="overview">Overview.</param>
        /// <returns>Current builder.</returns>
        public MatchRequestBuilder<TGeometry> Overview(Overview overview)
        {
            Request.Overview = overview;

            return this;
        }

        /// <summary>
        /// Sets timestamps.
        /// </summary>
        /// <param name="timestamps">Timestamps.</param>
        /// <returns>Current builder.</returns>
        public MatchRequestBuilder<TGeometry> Timestamps(params DateTimeOffset[] timestamps)
        {
            Request.Timestamps = timestamps;

            return this;
        }

        /// <summary>
        /// Sets radiuses.
        /// </summary>
        /// <param name="radiuses">Radiuses.</param>
        /// <returns>Current builder.</returns>
        public MatchRequestBuilder<TGeometry> Radiuses(params double[] radiuses)
        {
            Request.Radiuses = radiuses;

            return this;
        }

        /// <summary>
        /// Sets gaps.
        /// </summary>
        /// <param name="gaps">Gaps.</param>
        /// <returns>Current builder.</returns>
        public MatchRequestBuilder<TGeometry> Gaps(Gaps gaps)
        {
            Request.Gaps = gaps;

            return this;
        }

        /// <summary>
        /// Sets Tide property to true.
        /// </summary>
        /// <returns>Current builder.</returns>
        public MatchRequestBuilder<TGeometry> IsTidy()
        {
            Request.Tidy = true;

            return this;
        }

        /// <summary>
        /// Sets waypoints.
        /// </summary>
        /// <param name="waypoints">Waypoints.</param>
        /// <returns>Current builder.</returns>
        public MatchRequestBuilder<TGeometry> Waypoints(params int[] waypoints)
        {
            Request.Waypoints = waypoints;

            return this;
        }
    }
}