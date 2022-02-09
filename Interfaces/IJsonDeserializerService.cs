using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SMHIAPI.Models;

namespace SMHIAPI.Interfaces
{
    public interface IJsonDeserializerService
    {
        Task<Result<T>> TryDeserializeAsync<T>(Stream streamContent, CancellationToken cancellationToken);
    }
}
