using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Config;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VehicleManagement.Service.Implementation;
using VehicleManagement.Service.Interface;

namespace VehicleManagement.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            GlobalConfiguration.Configuration.UseMemoryStorage();
            GlobalConfiguration.Configuration.UseActivator(new HangfireActivator(host.Services));

            RecurringJob.AddOrUpdate<ICarReport>((x) => x.GetAllCarsReportAsync() , Cron.Hourly);
            
            using (new BackgroundJobServer())
            {
                Console.WriteLine("Hangfire Server started. Press ENTER to exit...");
                Console.ReadLine();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var config = new Config(hostContext.HostingEnvironment.EnvironmentName);
                    services.AddSingleton<IConfig>(config);
                    services.AddTransient<ICarReport, CarReport>();
                });
    }
}
