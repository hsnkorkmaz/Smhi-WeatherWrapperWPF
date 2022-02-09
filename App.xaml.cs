using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WpfApp1.Interfaces;
using WpfApp1.Services;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(app => app.AddJsonFile("appsettings.json"))
                .ConfigureServices((hostContext, services) =>
                {
                    var configuration = hostContext.Configuration;
                    
                    services.AddHttpClient(configuration["WeatherAPI:ClientName"], httpClient =>
                    {
                        httpClient.BaseAddress = new Uri(configuration["WeatherAPI:ClientUri"]);
                    });

                    //Dependency Injections
                    services.AddSingleton<IWeatherService, WeatherService>();
                    services.AddSingleton<ISmhiService, SmhiService>();
                    services.AddSingleton<IJsonDeserializerService, JsonDeserializerService>();
                    services.AddSingleton<IHttpRequestService, HttpRequestService>();
                    services.AddSingleton<ApiDemo>();
                }).Build();


            using var serviceScope = host.Services.CreateAsyncScope();
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var mainWindow = services.GetRequiredService<ApiDemo>();
                    mainWindow.Show();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    throw;
                }
            }
        }
    }
}
