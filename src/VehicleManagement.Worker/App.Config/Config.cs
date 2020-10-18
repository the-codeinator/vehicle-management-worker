using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace App.Config
{
    public class Config : IConfig
    {
        private readonly IConfigurationRoot _configuration;
        public Config(string env)
        {
            try
            {
                var builder = new ConfigurationBuilder()
               .SetBasePath(Path.Join(AppContext.BaseDirectory))
               .AddJsonFile($"appsettings.json", optional: false)
               .AddJsonFile($"appsettings.{env.ToString().ToLowerInvariant()}.json", optional: true)
               .AddEnvironmentVariables();
                _configuration = builder.Build();
            }
            catch (Exception ex)
            {

            }
        }
        private string GetConfig(string[] args)
        {
            return _configuration[$"{string.Join(":", args)}"];
        }
        public string Environment => GetConfig(new[] { "Environment" });

        public string BaseVehicleManagementUrl => GetConfig(new[] { "Vehiclemanagement", "BaseUrl" });

        public string GetCarsUrl
        {
            get
            {
                var carUrl= GetConfig(new[] { "Vehiclemanagement", "GetCars" });
                return $"{BaseVehicleManagementUrl}/{carUrl}";
            }
        }
    }
}
