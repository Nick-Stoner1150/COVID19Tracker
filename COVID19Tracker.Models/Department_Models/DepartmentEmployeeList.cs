using COVID19Tracker.Data.Employee_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Tracker.Models.Department_Models
{
   public class DepartmentEmployeeList
    {
        public string DepartmentName { get; set; }

        public List <Employee> Employees { get; set; }
    }
}
