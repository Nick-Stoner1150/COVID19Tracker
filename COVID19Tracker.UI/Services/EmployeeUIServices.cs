using COVID19Tracker.Models.Employee_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Tracker.UI.Services
{
   public class EmployeeUIServices : ServicesBase
    {
        private const string employeeRoute = "employee/";

        public async Task<EmployeeDetail> GetById(int id)
        {
            var employee = await base.GetById<EmployeeDetail>(employeeRoute, id);
            return employee;
        }

        public async Task<IEnumerable<EmployeeListItem>> GetAllEmployees(string route)
        {

            var listOfEmployees = await base.GetAll<EmployeeListItem>(employeeRoute);
            return listOfEmployees;
        }

        public async Task CreateEmployee(EmployeeCreate employee)
        { 
            await base.Create<EmployeeCreate>(employeeRoute, employee);
        }

        public async Task EditEmployee(EmployeeEdit employee, int id)
        {
            await base.UpdateEntity<EmployeeEdit>(employeeRoute, employee, id);
        }
        public async Task DeleteEmployee(int id)
        {
            await base.DeleteById(employeeRoute, id);
            
        }

        public async Task<IEnumerable<EmployeeListItem>> GetVaccinatedByDepartmentId(string route, int departmentID)
        {
            var listOfVaccinatedEmployees = await base.GetAllVaccinatedByDepartment<EmployeeListItem>(employeeRoute, departmentID);
            return listOfVaccinatedEmployees;
        }

        public EmployeeUIServices() : base()
        {

        }
    }
}
