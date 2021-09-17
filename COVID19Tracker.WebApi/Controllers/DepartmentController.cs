using COVID19Tracker.Models.Department_Models;
using COVID19Tracker.Models.DepartmentModel;
using COVID19Tracker.Services.DepartmentServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace COVID19Tracker.WebApi.Controllers
{
    public class DepartmentController : ApiController
    {
        private DepartmentService CreateDepartmentService()
        {
            
            var departmentService = new DepartmentService();
            return departmentService;
        }


        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] DepartmentCreate department)
        {
            if (department is null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = CreateDepartmentService();
            var success = await entity.Post(department);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();

        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var entity = CreateDepartmentService();
            var depts = await entity.Get();
            return Ok(depts);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetDeptEmploy()
        {
            var entity = CreateDepartmentService();
            var deptsEmploy = await entity.GetDeptEmploy();
            return Ok(deptsEmploy);
        }






        [HttpPut]
        public async Task<IHttpActionResult>Put([FromBody] DepartmentEdit department, [FromUri]string name)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = CreateDepartmentService();
            var success = await entity.Put(department, name);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromUri] string name)
        {
            
            var svc = CreateDepartmentService();
            var success = await svc.Delete(name);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }

    }
}
    

