using COVID19Tracker.Data;
using COVID19Tracker.Data.Department_Data;
using COVID19Tracker.Models.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Tracker.Services.DepartmentServices
{
    public class DepartmentService
    {
        private readonly Guid _userId;

        public DepartmentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateDepartment(DepartmentCreate model)
        {
            var entity =
                new Department()
                {
                    DepartmentId = model.DepartmentId,
                    DepartmentName = model.DepartmentName,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Departments.Add(entity);
                return ctx.SaveChanges() == 1;
            }


        }

        public bool UpdateDepartment(DepartmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Departments
                    .Single(e => e.DepartmentId == model.DepartmentId);

                entity.DepartmentName = model.DepartmentName;

                return ctx.SaveChanges() == 1;
            }
        }

        

    }

}
    

