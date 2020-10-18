using Hangfire;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleManagement.Worker
{
    public class HangfireActivator : JobActivator
    {
        private IServiceProvider _container;

        public HangfireActivator(IServiceProvider serviceProvider)
        {
            _container = serviceProvider;
        }

        public override object ActivateJob(Type type)
        {
            return _container.GetService(type);
        }
    }
}
