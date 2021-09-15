using COVID19Tracker.Models.DepartmentModel;
using COVID19Tracker.Services.DepartmentServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace COVID19Tracker.WebApi.Controllers
{
    public class DepartmentController : ApiController
    {
        private DepartmentService CreateDepartmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var teamService = new DepartmentService(userId);
            return departmentService;
        }



        public IHttpActionResult Post(DepartmentCreate department)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDepartmentService();

            if (!service.CreateDepartment(department))
                return InternalServerError();

            return Ok();
        }


        public IHttpActionResult Put(DepartmentEdit department)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateDepartmentService();

            if (!service.UpdateDepartment(department))
                return InternalServerError();

            return Ok();
        }

        








    }
}
    

