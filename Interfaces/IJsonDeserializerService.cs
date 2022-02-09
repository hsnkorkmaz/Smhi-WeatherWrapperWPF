using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Interfaces
{
    public interface IJsonDeserializerService
    {
        Task<Result<T>> TryDeserializeAsync<T>(Stream streamContent, CancellationToken cancellationToken);
    }
}
