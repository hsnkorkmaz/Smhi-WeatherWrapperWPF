using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SMHIAPI.Models;

namespace SMHIAPI.Interfaces
{
    public interface IHttpRequestService
    {
        Task<Result<T>> Request<T>(string clientName, HttpRequestMessage requestMessage,
            CancellationToken token, string requestUri = "");
    }
}
