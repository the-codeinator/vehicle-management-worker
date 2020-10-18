using App.Config;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VehicleManagement.Service.Interface;

namespace VehicleManagement.Service.Implementation
{
    public class CarReport : ICarReport
    {
        private readonly IConfig _config;
        public CarReport(IConfig config)
        {
            try
            {
                _config = config;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
           
        }
        public async Task GetAllCarsReportAsync()
        { 
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(_config.GetCarsUrl))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            Console.WriteLine(apiResponse);
                            return;
                        }
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
