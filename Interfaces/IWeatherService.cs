using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfApp1.Dtos.SMHI;
using WpfApp1.Models;

namespace WpfApp1.Interfaces
{
    public interface IWeatherService
    {
        Task<Result<List<Resource>>> GetParameters(CancellationToken token);
        Task<Result<List<Station>>> GetStations(CancellationToken token, string parameter);
        Task<Result<List<Period>>> GetPeriods(CancellationToken token, string parameter, string station);
        Task<Result<List<Value>>> GetDataValues(CancellationToken token, string parameter, string station, string period);
    }
}
