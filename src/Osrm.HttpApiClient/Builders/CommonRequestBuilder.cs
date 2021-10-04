using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Base class for building custom builders.
    /// </summary>
    /// <typeparam name="TRequest">Common request.</typeparam>
    /// <typeparam name="TBuilder">Common request builder.</typeparam>
    public abstract class CommonRequestBuilder<TRequest, TBuilder>
        where TRequest : CommonRequest
        where TBuilder : CommonRequestBuilder<TRequest, TBuilder>
    {
        protected readonly TRequest Request;

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="request">Common request.</param>
        public CommonRequestBuilder(TRequest request)
        {
            Request = request;
        }

        /// <summary>
        /// Disables generating hints.
        /// </summary>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TBuilder NotGenerateHints()
        {
            Request.GenerateHints = false;

            return (TBuilder)this;
        }

        /// <summary>
        /// Excludes provided class names from response.
        /// </summary>
        /// <param name="classNames">Class names to exclude.</param>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TBuilder Exclude(params ClassName[] classNames)
        {
            Request.Exclude = classNames;

            return (TBuilder)this;
        }

        /// <summary>
        /// Sets snapping.
        /// </summary>
        /// <param name="snapping">Snapping.</param>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TBuilder Snapping(Snapping snapping)
        {
            Request.Snapping = snapping;

            return (TBuilder)this;
        }

        /// <summary>
        /// Removes waypoints from the response.
        /// </summary>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TBuilder SkipWaypoints()
        {
            Request.SkipWaypoints = true;

            return (TBuilder)this;
        }

        /// <summary>
        /// Gets already built request.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TRequest Build()
            => Request;
    }
}
