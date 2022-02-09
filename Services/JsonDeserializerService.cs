using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using SMHIAPI.Interfaces;
using SMHIAPI.Models;

namespace SMHIAPI.Services
{
    public class JsonDeserializerService : IJsonDeserializerService
    {
        private readonly JsonSerializer _jsonSerializer;

        public JsonDeserializerService()
        {
            _jsonSerializer = new JsonSerializer { ContractResolver = new CamelCasePropertyNamesContractResolver() };
        }

        public async Task<Result<T>> TryDeserializeAsync<T>(Stream streamContent, CancellationToken token)
        {
            try
            {
                var result = await DeserializeAsync<T>(streamContent, token);
                return Result<T>.Ok(result);
            }
            catch (Exception e)
            {
                return Result<T>.Fail(e.Message);
            }
        }

        private async Task<T> DeserializeAsync<T>(Stream stream, CancellationToken token)
        {
            //JToken.LoadAsync used because it takes cancellation token
            using var streamReader = new StreamReader(stream);
            using var jsonReader = new JsonTextReader(streamReader);
            var loaded = await JToken.LoadAsync(jsonReader, token);
            return loaded.ToObject<T>(_jsonSerializer);
        }
    }
}
