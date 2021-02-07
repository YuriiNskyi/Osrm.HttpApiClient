namespace Osrm.HttpApiClient
{
    /// <summary>
    /// Fluent way to build Trip requests.
    /// </summary>
    /// <typeparam name="TGeometry">Geometry.</typeparam>
    public class TripRequestBuilder<TGeometry> : CommonRequestBuilder<TripRequest<TGeometry>, TripRequestBuilder<TGeometry>>
        where TGeometry : Geometry
    {
        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="request">Trip request specified by Geometry.</param>
        public TripRequestBuilder(TripRequest<TGeometry> request)
            : base(request)
        {
        }

        /// <summary>
        /// Returns steps in response.
        /// </summary>
        /// <returns>Current builder.</returns>
        public TripRequestBuilder<TGeometry> ReturnSteps()
        {
            Request.Steps = true;

            return this;
        }

        /// <summary>
        /// Returns annotations in response.
        /// </summary>
        /// <returns>Current builder.</returns>
        public TripRequestBuilder<TGeometry> ReturnAnnotations()
        {
            Request.Annotations = true;

            return this;
        }

        /// <summary>
        /// Sets overview.
        /// </summary>
        /// <param name="overview">Overview.</param>
        /// <returns>Current builder.</returns>
        public TripRequestBuilder<TGeometry> Overview(Overview overview)
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
        public TripRequestBuilder<TGeometry> WithRoundTrip(
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
        public TripRequestBuilder<TGeometry> WithoutRoundtrip()
        {
            Request.WithoutRoundtrip();

            return this;
        }
    }
}