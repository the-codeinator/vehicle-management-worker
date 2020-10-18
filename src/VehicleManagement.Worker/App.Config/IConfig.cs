using System;
using System.Collections.Generic;
using System.Text;

namespace App.Config
{
    public interface IConfig
    { 
        string Environment { get; }
        string BaseVehicleManagementUrl { get; }
        string GetCarsUrl { get; }
    }
}
