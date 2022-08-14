namespace Osrm.HttpApiClient
{
    public interface IOsrmRequest
    {
        public string Service { get; }

        public string Version { get; }

        public string Uri { get; }
    }
}