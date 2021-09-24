using COVID19Tracker.Models.Department_Models;
using COVID19Tracker.Models.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Tracker.UI.Services
{
    public class DepartmentUIServices : ServicesBase
    {
        private const string departmentRoute = "department/";

        public async Task CreateDepartment(DepartmentCreate department)
        {
            await base.Create<DepartmentCreate>(departmentRoute, department);
        }

        public async Task<DepartmentList> GetById(int id)
        {
            var department = await base.GetById<DepartmentList>(departmentRoute, id);
            return department;
        }

        public async Task<IEnumerable<DepartmentList>> GetAllDepartments(string route)
        {

            var listOfDepartments = await base.GetAll<DepartmentList>(departmentRoute);
            return listOfDepartments;
        }
    }
}
