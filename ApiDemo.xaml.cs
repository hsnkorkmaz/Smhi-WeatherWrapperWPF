using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SMHIAPI.Interfaces;

namespace SMHIAPI
{
    /// <summary>
    /// Interaction logic for ApiDemo.xaml
    /// </summary>
    public partial class ApiDemo : Window
    {
        private readonly IWeatherService _weatherService;
        private CancellationTokenSource _cancellationTokenSource;

        public ApiDemo(IWeatherService weatherService)
        {
            InitializeComponent();
            _cancellationTokenSource = new CancellationTokenSource();
            _weatherService = weatherService;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var token = _cancellationTokenSource.Token;
            await LoadParameters(token);
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private async void LParameters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LStations.Items.Clear();
            LPeriods.Items.Clear();
            LData.Items.Clear();

            if (LParameters.SelectedItem == null) return;
            var selectedItem = (KeyValuePair<string, string>)LParameters.SelectedItem;
            var token = _cancellationTokenSource.Token;

            await LoadStations(token, selectedItem.Key);
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private async void LStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LPeriods.Items.Clear();
            LData.Items.Clear();
            if (LStations.SelectedItem == null || LParameters.SelectedItem == null) return;
            var selectedStation = (KeyValuePair<string, string>)LStations.SelectedItem;
            var selectedParameter = (KeyValuePair<string, string>)LParameters.SelectedItem;
            var token = _cancellationTokenSource.Token;

            await LoadPeriods(token, selectedParameter.Key, selectedStation.Key);
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private async void LPeriods_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LData.Items.Clear();
            if (LStations.SelectedItem == null || LParameters.SelectedItem == null || LPeriods.SelectedItem == null) return;
            
            var selectedStation = (KeyValuePair<string, string>) LStations.SelectedItem;
            var selectedParameter = (KeyValuePair<string, string>) LParameters.SelectedItem;
            var selectedPeriod = (KeyValuePair<string, string>) LPeriods.SelectedItem;
            var token = _cancellationTokenSource.Token;
            await LoadData(token, selectedParameter.Key, selectedStation.Key, selectedPeriod.Key);
            _cancellationTokenSource = new CancellationTokenSource();
        }

        private async Task LoadParameters(CancellationToken token)
        {
            var result = await _weatherService.GetParameters(token);

            if (!result.Success)
            {
                MessageBox.Show(result.Message);
                return;
            }
            foreach (var resource in result.Data)
            {
                //await Task.Delay(1, token);
                LParameters.Items.Add(new KeyValuePair<string, string>(resource.Key, resource.Title + " - " + resource.Summary));
            }
            if (LParameters.Items.Count > 0) LParameters.SelectedIndex = 0;

            LParameters.SelectionChanged -= LParameters_SelectionChanged;
            LParameters.SelectionChanged += LParameters_SelectionChanged;
        }

        private async Task LoadStations(CancellationToken token, string parameter)
        {
            LStations.Items.Clear();
            var result = await _weatherService.GetStations(token, parameter);

            if (!result.Success)
            {
                MessageBox.Show(result.Message);
                return;
            }
            foreach (var station in result.Data)
            {
                //await Task.Delay(1, token);
                LStations.Items.Add(new KeyValuePair<string, string>(station.Id.ToString(), station.Name));
            }
            if (LStations.Items.Count > 0) LStations.SelectedIndex = 0;

            LStations.SelectionChanged -= LStations_SelectionChanged;
            LStations.SelectionChanged += LStations_SelectionChanged;
        }
        
        private async Task LoadPeriods(CancellationToken token, string parameter, string station)
        {
            LPeriods.Items.Clear();
            var result = await _weatherService.GetPeriods(token, parameter, station);

            if (!result.Success)
            {
                MessageBox.Show(result.Message);
                return;
            }
            foreach (var period in result.Data)
            {
                if (period.Key == "corrected-archive") break;

                //await Task.Delay(1, token);
                LPeriods.Items.Add(new KeyValuePair<string, string>(period.Key, period.Title));
            }
            if (LPeriods.Items.Count > 0) LPeriods.SelectedIndex = 0;
            
            LPeriods.SelectionChanged -= LPeriods_SelectionChanged;
            LPeriods.SelectionChanged += LPeriods_SelectionChanged;
        }

        private async Task LoadData(CancellationToken token, string parameter, string station, string period)
        {
            LData.Items.Clear();
            var result = await _weatherService.GetDataValues(token, parameter, station, period);
            if (!result.Success)
            {
                LData.Items.Add(new KeyValuePair<string, string>("NO-DATA", result.Message));
                //MessageBox.Show(result.Message);
                return;
            }

            foreach (var value in result.Data)
            {
                LData.Items.Add(new KeyValuePair<string, string>(value.Values, $"D: {await GetDateFromUnixTimeStamp(value.Date)} - V: {value.Values}"));
            }

            if (LData.Items.Count > 0) LData.SelectedIndex = 0;
            //LData.SelectionChanged += LData_SelectionChanged;
        }
        
        private async Task<string> GetDateFromUnixTimeStamp(long timestamp)
        {
            return timestamp == 0 
                ? "" 
                : new DateTime(1970, 1, 1).AddMilliseconds(timestamp).ToString(CultureInfo.CurrentCulture);
        }
    }
}
