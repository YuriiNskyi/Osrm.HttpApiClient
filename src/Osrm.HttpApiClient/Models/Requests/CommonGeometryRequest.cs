namespace Osrm.HttpApiClient
{
    public abstract record CommonGeometryRequest<TGeometry> : CommonRequest
        where TGeometry : Geometry
    {
        protected CommonGeometryRequest(string profile, Coordinates coordinates)
            : base(profile, coordinates)
        {
        }

        /// <summary>
        /// Returned route geometry format (influences overview and per step).
        /// </summary>
        public abstract string Geometries { get; }
    }
}
