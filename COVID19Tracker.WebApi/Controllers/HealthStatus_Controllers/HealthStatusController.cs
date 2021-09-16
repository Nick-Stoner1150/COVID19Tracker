using COVID19Tracker.Models.HealthStatus_Models;
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
        [HttpPost]
        public async Task<IHttpActionResult> Post (HealthStatusCreate healthStatus)
        {
            if (healthStatus is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


        }
    }
}
