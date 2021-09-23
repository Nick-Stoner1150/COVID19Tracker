using COVID19Tracker.Models.HealthStatus_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Tracker.UI.Services
{
    public class HealthStatusUIServices : ServicesBase
    {
        private const string healthStatusRoute = "healthstatus/";

        public async Task CreateHealthStatus(HealthStatusCreate healthStatus)
        {
            await base.Create<HealthStatusCreate>(healthStatusRoute, healthStatus);
        }

        public async Task<HealthStatusDetail> GetById(int id)
        {
            var healthStatus = await base.GetById<HealthStatusDetail>(healthStatusRoute, id);
            return healthStatus;
        }
    }
}
