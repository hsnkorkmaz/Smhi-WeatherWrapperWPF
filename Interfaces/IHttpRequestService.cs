using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Interfaces
{
    public interface IHttpRequestService
    {
        Task<Result<T>> Request<T>(string clientName, HttpRequestMessage requestMessage,
            CancellationToken token, string requestUri = "");
    }
}
