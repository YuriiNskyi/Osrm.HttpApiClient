using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Fluent way to build Table requests.
    /// </summary>
    public class TableRequestBuilder : CommonRequestBuilder<TableRequest, TableRequestBuilder>
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="profile">Profile.</param>
        /// <param name="coordinates">Coordinates.</param>
        public TableRequestBuilder(string profile, Coordinates coordinates)
            : base(new TableRequest(profile, coordinates))
        {
        }

        /// <summary>
        /// Sets sources.
        /// </summary>
        /// <param name="sources">Sources.</param>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TableRequestBuilder Sources(params int[] sources)
        {
            Request.Sources = sources;

            return this;
        }

        /// <summary>
        /// Sets destinations.
        /// </summary>
        /// <param name="destinations">Destinations</param>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TableRequestBuilder Destinations(params int[] destinations)
        {
            Request.Destinations = destinations;

            return this;
        }

        /// <summary>
        /// Sets annotations.
        /// </summary>
        /// <param name="annotations">Annotations.</param>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TableRequestBuilder Annotations(Annotations annotations)
        {
            Request.Annotations = annotations;

            return this;
        }

        /// <summary>
        /// Sets fallback speed.
        /// </summary>
        /// <param name="fallbackSpeed">Fallback speed.</param>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TableRequestBuilder FallbackSpeed(double fallbackSpeed)
        {
            Request.FallbackSpeed = fallbackSpeed;

            return this;
        }

        /// <summary>
        /// Sets fallback coordinate.
        /// </summary>
        /// <param name="fallbackCoordinate">Fallback coordinate.</param>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TableRequestBuilder FallbackCoordinate(FallbackCoordinate fallbackCoordinate)
        {
            Request.FallbackCoordinate = fallbackCoordinate;

            return this;
        }

        /// <summary>
        /// Sets scale factor.
        /// </summary>
        /// <param name="scaleFactor">Scale factor.</param>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TableRequestBuilder ScaleFactor(double scaleFactor)
        {
            Request.ScaleFactor = scaleFactor;

            return this;
        }
    }
}