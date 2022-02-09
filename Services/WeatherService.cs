using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfApp1.Dtos.SMHI;
using WpfApp1.Interfaces;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly ISmhiService _smhiService;
        private const string ApiVersion = "1.0";

        public WeatherService(ISmhiService smhiService)
        {
            _smhiService = smhiService;
        }
        
        public async Task<Result<List<Resource>>> GetParameters(CancellationToken token)
        {
            var result = await _smhiService.GetVersionResult(token, ApiVersion);

            if(!result.Success) return Result<List<Resource>>.Fail(result.Message!);
            if (result.Data.Resource == null) return Result<List<Resource>>.Fail("There is no resource to show");
            return Result<List<Resource>>.Ok(result.Data.Resource.Where(resource => resource.Title != null).ToList());
        }

        public async Task<Result<List<Station>>> GetStations(CancellationToken token, string parameter)
        {
            var result = await _smhiService.GetParameterResult(token, ApiVersion, parameter);
            if (!result.Success) return Result<List<Station>>.Fail(result.Message!);
            if (result.Data.Station == null) return Result<List<Station>>.Fail("There is no station to show");
            return Result<List<Station>>.Ok(result.Data.Station.Where(station => station.Name != null).ToList());
        }

        public async Task<Result<List<Period>>> GetPeriods(CancellationToken token, string parameter, string station)
        {
            var result = await _smhiService.GetStationResult(token, ApiVersion, parameter, station);
            if (!result.Success) return Result<List<Period>>.Fail(result.Message!);
            if (result.Data.Period == null) return Result<List<Period>>.Fail("There is no period to show");
            return Result<List<Period>>.Ok(result.Data.Period.Where(period => period.Title != null).ToList());
        }

        public async Task<Result<List<Value>>> GetDataValues(CancellationToken token, string parameter, string station, string period)
        {
            var result = await _smhiService.GetDataStationResult(token, ApiVersion, parameter, station, period);
            if (!result.Success) return Result<List<Value>>.Fail(result.Message!);
            if (result.Data.Value == null) return Result<List<Value>>.Fail("There is no value to show");
            return Result<List<Value>>.Ok(result.Data.Value.Where(value => value != null).ToList());
        }
    }
}
