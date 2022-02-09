using System;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SMHIAPI.Interfaces;
using SMHIAPI.Services;

namespace SMHIAPI
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
