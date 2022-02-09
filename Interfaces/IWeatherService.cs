using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SMHIAPI.Dtos.SMHI;
using SMHIAPI.Models;

namespace SMHIAPI.Interfaces
{
    public interface IWeatherService
    {
        Task<Result<List<Resource>>> GetParameters(CancellationToken token);
        Task<Result<List<Station>>> GetStations(CancellationToken token, string parameter);
        Task<Result<List<Period>>> GetPeriods(CancellationToken token, string parameter, string station);
        Task<Result<List<Value>>> GetDataValues(CancellationToken token, string parameter, string station, string period);
    }
}
