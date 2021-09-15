using COVID19Tracker.Data;
using COVID19Tracker.Data.Employee_Data;
using COVID19Tracker.Models.Employee_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Tracker.Services.Employee_Services
{
    public class EmployeeServices
    {
        public async Task<bool> Post(EmployeeCreate employee)
        {
            var entity = new Employee
            {
                BadgeId = employee.BadgeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DepartmentId = employee.DepartmentId,
                HealthStatusId = employee.HealthStatusId
            };

            using (var ctx = new ApplicationDbContext())
            {
                
            }
        }
    }
}
