namespace Osrm.HttpApiClient
{
    public interface IOsrmResponse
    {
        public ResponseCode Code { get; set; }

        public string Message { get; set; }

        public bool IsValid { get; }
    }
}
