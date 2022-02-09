using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using WpfApp1.Interfaces;
using WpfApp1.Models;

namespace WpfApp1.Services
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
