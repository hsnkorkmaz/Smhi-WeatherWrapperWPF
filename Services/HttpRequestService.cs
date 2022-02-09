using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfApp1.Interfaces;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class HttpRequestService : IHttpRequestService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IJsonDeserializerService _jsonDeserializerService;

        public HttpRequestService(IHttpClientFactory httpClientFactory, IJsonDeserializerService jsonDeserializerService)
        {
            _httpClientFactory = httpClientFactory;
            _jsonDeserializerService = jsonDeserializerService;
        }

        public async Task<Result<T>> Request<T>(string clientName, HttpRequestMessage requestMessage,
            CancellationToken token, string requestUri = "")
        {
            var httpClient = _httpClientFactory.CreateClient(clientName);
            var request = await CloneHttpRequestMessageAsync(requestMessage);

            request.RequestUri = new Uri($"{httpClient.BaseAddress}{requestUri}");

            try
            {
                using var response = await httpClient.SendAsync(request, token);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result<T>.Fail(response.StatusCode == HttpStatusCode.NotFound
                        ? "Api was not found 404"
                        : $"Did not receive 200 OK status code {response.StatusCode}");
                }

                if (response.Content == null)
                {
                    return Result<T>.Fail("Response content is null");
                }

                var responseStream = await response.Content.ReadAsStreamAsync(token);
                var deserializationResult = await _jsonDeserializerService.TryDeserializeAsync<T>(responseStream, token);

                return deserializationResult.Success
                    ? deserializationResult
                    : Result<T>.Fail($"Failed to deserialize stream to {nameof(T)}");
            }
            catch (HttpRequestException)
            {
                return Result<T>.Fail("HttpRequestException when calling the API");
            }
            catch (TimeoutException)
            {
                return Result<T>.Fail("TimeoutException during call to API");
            }
            catch (OperationCanceledException)
            {
                return Result<T>.Fail("Task was canceled during call to API");
            }
            catch (Exception)
            {
                return Result<T>.Fail("Unhandled exception when calling the API");
            }
        }



        public static async Task<HttpRequestMessage> CloneHttpRequestMessageAsync(HttpRequestMessage req)
        {
            var clone = new HttpRequestMessage(req.Method, req.RequestUri);
            
            var ms = new MemoryStream();
            if (req.Content != null)
            {
                await req.Content.CopyToAsync(ms).ConfigureAwait(false);
                ms.Position = 0;
                clone.Content = new StreamContent(ms);
                
                foreach (var h in req.Content.Headers)
                    clone.Content.Headers.Add(h.Key, h.Value);
            }
            
            clone.Version = req.Version;

            foreach (KeyValuePair<string, object> prop in req.Properties)
                clone.Properties.Add(prop);

            foreach (var (key, value) in req.Headers)
                clone.Headers.TryAddWithoutValidation(key, value);

            return clone;
        }
    }
}
