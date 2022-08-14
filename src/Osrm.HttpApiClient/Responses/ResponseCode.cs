namespace Osrm.HttpApiClient
{
    public enum ResponseCode
    {
        /// <summary>
        /// Request could be processed as expected.
        /// </summary>
        Ok,

        /// <summary>
        /// URL string is invalid.
        /// </summary>
        InvalidUrl,

        /// <summary>
        /// Service name is invalid.
        /// </summary>
        InvalidService,

        /// <summary>
        /// Version is not found.
        /// </summary>
        InvalidVersion,

        /// <summary>
        /// Options are invalid.
        /// </summary>
        InvalidOptions,

        /// <summary>
        /// The query string is syntactically malformed.
        /// </summary>
        InvalidQuery,

        /// <summary>
        /// The successfully parsed query parameters are invalid.
        /// </summary>
        InvalidValue,

        /// <summary>
        /// One of the supplied input coordinates could not snap to street segment.
        /// </summary>
        NoSegment,

        /// <summary>
        /// The request size violates one of the service specific request size restrictions.
        /// </summary>
        TooBig,

        /// <summary>
        /// No route found.
        /// </summary>
        NoRoute,

        /// <summary>
        /// No route found.
        /// </summary>
        NoTable,

        /// <summary>
        /// This request is not supported.
        /// </summary>
        NotImplemented,

        /// <summary>
        /// No matchings found.
        /// </summary>
        NoMatch,

        /// <summary>
        /// No trips found because input coordinates are not connected.
        /// </summary>
        NoTrips,
    }
}
