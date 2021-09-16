using COVID19Tracker.Models.HealthStatus_Models;
using COVID19Tracker.Services.HealthStatus_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace COVID19Tracker.WebApi.Controllers.HealthStatus_Controllers
{
    public class HealthStatusController : ApiController
    {
        private HealthStatusService HealthStatusService()
        {
            var svc = new HealthStatusService();
            return svc;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post (HealthStatusCreate healthStatus)
        {
            if (healthStatus is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var svc = HealthStatusService();
            var success = await svc.Post(healthStatus);

            if (success)
            {
                return Ok("Employee health status has successfully been submitted to the database.");
            }
            return InternalServerError();
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(HealthStatusEdit healthStatus, int id)
        {
            if (id < 1 || id != healthStatus.HealthStatusId || healthStatus is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = HealthStatusService();
            var success = await svc.Put(healthStatus, id);
            if (success)
            {
                return Ok("Updated information submitted to the database.");
            }
            return InternalServerError();
        }
    }
}
