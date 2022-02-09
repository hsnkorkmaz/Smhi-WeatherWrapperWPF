using System.Threading;
using System.Threading.Tasks;
using SMHIAPI.Dtos.SMHI.Main;
using SMHIAPI.Models;

namespace SMHIAPI.Interfaces
{
    public interface ISmhiService
    {
        Task<Result<CategoryResult>> GetCategoryResult(CancellationToken token);

        Task<Result<VersionResult>> GetVersionResult(CancellationToken token, string version);

        Task<Result<ParameterResult>> GetParameterResult(CancellationToken token, string version, string parameter);

        Task<Result<StationResult>> GetStationResult(CancellationToken token, string version, string parameter,
            string station);

        Task<Result<StationSetResult>> GetStationSetResult(CancellationToken token, string version, string parameter,
            string stationSet);

        Task<Result<PeriodResult>> GetPeriodStationResult(CancellationToken token, string version, string parameter,
            string station, string period);

        Task<Result<PeriodResult>> GetPeriodStationSetResult(CancellationToken token, string version, string parameter,
            string stationSet, string period);

        Task<Result<DataStationResult>> GetDataStationResult(CancellationToken token, string version, string parameter,
            string station, string period);
    }
}
