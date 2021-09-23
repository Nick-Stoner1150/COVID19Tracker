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
    }
}
