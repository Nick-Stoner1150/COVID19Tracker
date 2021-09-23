using COVID19Tracker.Data;
using COVID19Tracker.Data.Department_Data;
using COVID19Tracker.Models.Department_Models;
using COVID19Tracker.Models.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Tracker.Services.DepartmentServices
{
    public class DepartmentService
    {

        public async Task<bool> Post(DepartmentCreate department)
        {
            var entity = new Department
            {
                DepartmentName = department.DepartmentName,                
                DepartmentLocation = department.DepartmentLocation
                
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Departments.Add(entity);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
        public async Task<IEnumerable<DepartmentList>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    await
                    ctx
                    .Departments                    
                    .Select(d => new DepartmentList

                    {                        
                        DepartmentName = d.DepartmentName,
                        DepartmentLocation = d.DepartmentLocation

                    }).ToListAsync();

                return query;
            }
        }

        public async Task<IEnumerable<DepartmentEmployeeList>> GetDeptEmploy()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    await
                    ctx
                    .Departments
                    .Select(d => new DepartmentEmployeeList

                    {
                        DepartmentName = d.DepartmentName,
                        Employees = d.Employees

                    }).ToListAsync();

                return query;
            }
        }

        public async Task<bool> Put(DepartmentEdit model, string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Departments.FindAsync(name);
                if (entity is null)
                {
                    return false;
                }

                entity.DepartmentName = model.DepartmentName;
                entity.DepartmentLocation = model.DepartmentLocation;






                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> Delete(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Departments.FindAsync(name);
                if (entity is null)
                {
                    return false;
                }
                ctx.Departments.Remove(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }



    }

}
    

