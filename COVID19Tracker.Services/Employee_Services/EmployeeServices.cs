using COVID19Tracker.Data;
using COVID19Tracker.Data.Employee_Data;
using COVID19Tracker.Models.Employee_Models;
using COVID19Tracker.Models.Employee_Models.Employee_Paginations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                var department = await ctx.Departments.FindAsync(employee.DepartmentId);
                var healthStatus = await ctx.HealthStatuses.FindAsync(employee.HealthStatusId);

                if (department is null || healthStatus is null)
                    return false;

                // entity.Department.EmployeeList.Add(entity);

                ctx.Employees.Add(entity);
                return await ctx.SaveChangesAsync() > 0;
            }
        }

        public async Task<IEnumerable<EmployeeListItem>> GetAll(int pageNumber, int pageSize)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    await
                    ctx
                    .Employees
                    .Select(e => new EmployeeListItem
                    {
                        ID = e.ID,
                        BadgeId = e.BadgeId,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        DepartmentName = e.Department.DepartmentName,
                        DepartmentId = e.DepartmentId,
                        HealthStatusId = e.HealthStatusId
                    })
                    .OrderBy(e => e.LastName)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return query;
            }
        }

        public async Task<EmployeeDetail> Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var employee =
                    await
                    ctx
                    .Employees
                    .SingleOrDefaultAsync(e => e.ID == id);

                if (employee is null)
                    return null;

                return new EmployeeDetail
                {
                    ID = employee.ID,
                    BadgeId = employee.BadgeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    DepartmentId = employee.DepartmentId,
                    DepartmentName = employee.Department.DepartmentName,
                    HealthStatusId = employee.HealthStatusId,
                    Vaccinated = employee.HealthStatus.Vaccinated,
                    HasCovid = employee.HealthStatus.HasCovid,
                    Hospitalized = employee.HealthStatus.Hospitalized,
                    Comorbities = employee.HealthStatus.Comorbidities,
                    QuarantinedDate = employee.HealthStatus.QuarantinedDate,
                    LastTestedDate = employee.HealthStatus.LastTestedDate,
                    CreatedDate = employee.CreatedDate,
                    ModifiedDate = employee.ModifiedDate
                };
            }
        }

        public async Task<IEnumerable<EmployeeListItem>> GetVaccinatedByDepartment(int departmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var employees =
                    await
                    ctx
                    .Employees
                    .Where(e => e.HealthStatus.Vaccinated && e.DepartmentId == departmentId)
                    .Select(e => new EmployeeListItem
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        DepartmentId = e.DepartmentId,
                        DepartmentName = e.Department.DepartmentName,
                        HealthStatusId = e.HealthStatusId
                    }).ToListAsync();

                return employees;
            }
        }

        public async Task<bool> Put(EmployeeEdit employee, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldData = await ctx.Employees.FindAsync(id);
                if (oldData is null)
                    return false;

                oldData.BadgeId = employee.BadgeId;
                oldData.FirstName = employee.FirstName;
                oldData.LastName = employee.LastName;
                oldData.DepartmentId = employee.DepartmentId;

                return await ctx.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldData = await ctx.Employees.FindAsync(id);
                if (oldData is null)
                    return false;

                ctx.Employees.Remove(oldData);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}
