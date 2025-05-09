using System.Net;

namespace Osrm.HttpApiClient
{
    public record OsrmHttpApiResponse<TResult>
    {
        public OsrmHttpApiResponse(
            bool isSuccess,
            HttpStatusCode statusCode,
            TResult? result)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Result = result;
        }

        public bool IsSuccess { get; }

        public HttpStatusCode StatusCode { get; }

        public TResult? Result { get; }
    }
}
