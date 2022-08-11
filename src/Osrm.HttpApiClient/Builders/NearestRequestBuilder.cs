using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Fluent way to build Nearest requests.
    /// </summary>
    public class NearestRequestBuilder<TFormat>
        : CommonRequestBuilder<NearestRequest<TFormat>, NearestRequestBuilder<TFormat>, TFormat>
        where TFormat : struct, IFormat
    {
        public NearestRequestBuilder(string profile, Coordinate coordinate)
            : base(new NearestRequest<TFormat>(profile, coordinate))
        {
        }

        /// <summary>
        /// Sets nearest segments.
        /// </summary>
        /// <param name="nearestSegments">Nearest segments.</param>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public NearestRequestBuilder<TFormat> NearestSegments(int nearestSegments)
        {
            Request.NearestSegments = nearestSegments;

            return this;
        }
    }
}