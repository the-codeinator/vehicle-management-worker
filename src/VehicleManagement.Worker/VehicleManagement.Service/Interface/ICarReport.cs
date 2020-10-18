using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagement.Service.Interface
{
    public interface ICarReport
    {
        Task GetAllCarsReportAsync();
    }
}
