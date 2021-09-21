using COVID19Tracker.Models.Employee_Models;
using COVID19Tracker.Models.Pagination_Models;
using COVID19Tracker.Services.Employee_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace COVID19Tracker.WebApi.Controllers.Employee_Controller
{
    public class EmployeeController : ApiController
    {
        private EmployeeServices CreateEmployeeService()
        {
            var svc = new EmployeeServices();
            return svc;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] EmployeeCreate employee)
        {
            if (employee is null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var svc = CreateEmployeeService();
            var success = await svc.Post(employee);

            if (success)
                return Ok($"You successfully added {employee.FirstName} {employee.LastName} to the Covid-19 Tracker Database!!");

            return InternalServerError();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll([FromUri] PaginationParameters parameters)
        {
            var svc = CreateEmployeeService();
            var employees = await svc.GetAll(parameters.PageNumber, parameters.PageSize);
            return Ok(employees);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            var svc = CreateEmployeeService();
            var employee = await svc.Get(id);
            return Ok(employee);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetVaccinatedByDepartmentId([FromUri] int departmentId)
        {
            var svc = CreateEmployeeService();
            var employees = await svc.GetVaccinatedByDepartment(departmentId);
            return Ok(employees);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody] EmployeeEdit employee, [FromUri] int id)
        {
            if (id<1 || id!=employee.ID || employee is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateEmployeeService();
            var success = await svc.Put(employee, id);
            if (success)
            {
                return Ok("You sucessfully updated the employee!");
            }
            return InternalServerError();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            if (id < 1)
                return BadRequest();

            var svc = CreateEmployeeService();
            var success = svc.Delete(id);
            if (await success)
                return Ok();
            return InternalServerError();
        }
    }
}
