using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfApp1.Dtos.SMHI.Main;
using WpfApp1.Interfaces;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class SmhiService : ISmhiService
    {
        private readonly IHttpRequestService _httpRequestService;
        private readonly HttpRequestMessage _defaultHttpRequestMessage = new() { Method = HttpMethod.Get };
        private const string ClientName = "SMHI";
        private const string ResponseType = ".json";

        public SmhiService(IHttpRequestService httpRequestService)
        {
            _httpRequestService = httpRequestService;
        }

        public async Task<Result<CategoryResult>> GetCategoryResult(CancellationToken token)
        {
            // {ext}
            string requestUri = $"{ResponseType}";
            return await _httpRequestService.Request<CategoryResult>(ClientName, _defaultHttpRequestMessage, token,
                requestUri);
        }

        public async Task<Result<VersionResult>> GetVersionResult(CancellationToken token, string version)
        {
            // api/version/{version}.{ext}
            string requestUri = $"/version/{version}{ResponseType}";
            return await _httpRequestService.Request<VersionResult>(ClientName, _defaultHttpRequestMessage, token, requestUri);
        }

        public async Task<Result<ParameterResult>> GetParameterResult(CancellationToken token, string version, string parameter)
        {
            // api/version/{version}/parameter/{parameter}.{ext}
            string requestUri = $"/version/{version}/parameter/{parameter}{ResponseType}";
            return await _httpRequestService.Request<ParameterResult>(ClientName, _defaultHttpRequestMessage, token, requestUri);
        }

        public async Task<Result<StationResult>> GetStationResult(CancellationToken token, string version, string parameter, string station)
        {
            // api/version/{version}/parameter/{parameter}/station/{station}.{ext}
            string requestUri = $"/version/{version}/parameter/{parameter}/station/{station}{ResponseType}";
            return await _httpRequestService.Request<StationResult>(ClientName, _defaultHttpRequestMessage, token, requestUri);
        }

        public async Task<Result<StationSetResult>> GetStationSetResult(CancellationToken token, string version, string parameter, string stationSet)
        {
            // api/version/{version}/parameter/{parameter}/station-set/{stationSet}.{ext}
            string requestUri = $"/version/{version}/parameter/{parameter}/station-set/{stationSet}{ResponseType}";
            return await _httpRequestService.Request<StationSetResult>(ClientName, _defaultHttpRequestMessage, token, requestUri);
        }

        public async Task<Result<PeriodResult>> GetPeriodStationResult(CancellationToken token, string version, string parameter, string station, string period)
        {
            // api/version/{version}/parameter/{parameter}/station/{station}/period/{period}.{ext}
            string requestUri = $"/version/{version}/parameter/{parameter}/station/{station}/period/{period}{ResponseType}";
            return await _httpRequestService.Request<PeriodResult>(ClientName, _defaultHttpRequestMessage, token, requestUri);
        }

        public async Task<Result<PeriodResult>> GetPeriodStationSetResult(CancellationToken token, string version, string parameter, string stationSet, string period)
        {
            // api/version/{version}/parameter/{parameter}/station-set/{stationSet}/period/{period}.{ext}
            string requestUri = $"/version/{version}/parameter/{parameter}/station-set/{stationSet}/period/{period}{ResponseType}";
            return await _httpRequestService.Request<PeriodResult>(ClientName, _defaultHttpRequestMessage, token, requestUri);
        }

        public async Task<Result<DataStationResult>> GetDataStationResult(CancellationToken token, string version, string parameter, string station, string period)
        {
            // api/version/{version}/parameter/{parameter}/station/{station}/period/{period}/data.{ext}
            string requestUri = $"/version/{version}/parameter/{parameter}/station/{station}/period/{period}/data{ResponseType}";
            return await _httpRequestService.Request<DataStationResult>(ClientName, _defaultHttpRequestMessage, token, requestUri);
        }

        public async Task<Result<DataStationResult>> GetDataStationSetResult(CancellationToken token, string version, string parameter, string stationSet, string period)
        {
            // api/version/{version}/parameter/{parameter}/station-set/{stationSet}/period/{period}/data.{ext}
            string requestUri = $"/version/{version}/parameter/{parameter}/station-set/{stationSet}/period/{period}/data{ResponseType}";
            return await _httpRequestService.Request<DataStationResult>(ClientName, _defaultHttpRequestMessage, token, requestUri);
        }
    }
}
