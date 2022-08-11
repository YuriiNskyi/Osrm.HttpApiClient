using System.Runtime.CompilerServices;

namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Fluent way to build Table requests.
    /// </summary>
    public class TableRequestBuilder<TFormat>
        : CommonRequestBuilder<TableRequest<TFormat>, TableRequestBuilder<TFormat>, TFormat>
        where TFormat : struct, IFormat
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="profile">Profile.</param>
        /// <param name="coordinates">Coordinates.</param>
        public TableRequestBuilder(string profile, Coordinates coordinates)
            : base(new TableRequest<TFormat>(profile, coordinates))
        {
        }

        /// <summary>
        /// Sets sources.
        /// </summary>
        /// <param name="sources">Sources.</param>
        /// <returns>Current builder.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public TableRequestBuilder<TFormat> Sources(params int[] sources)
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
        public TableRequestBuilder<TFormat> Destinations(params int[] destinations)
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
        public TableRequestBuilder<TFormat> Annotations(TableAnnotations annotations)
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
        public TableRequestBuilder<TFormat> FallbackSpeed(double fallbackSpeed)
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
        public TableRequestBuilder<TFormat> FallbackCoordinate(FallbackCoordinate fallbackCoordinate)
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
        public TableRequestBuilder<TFormat> ScaleFactor(double scaleFactor)
        {
            Request.ScaleFactor = scaleFactor;

            return this;
        }
    }
}