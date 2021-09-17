using COVID19Tracker.Data.Employee_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Tracker.Data.Department_Data
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string DepartmentLocation { get; set; }

        public DateTime? LastCleanDate { get; set; }

        public int WeeklyTests { get; set; }

        public virtual List<Employee> Employees { get; set; } = new List<Employee>();

        public Department()
        {

        }

        public Department(string departmentName, List<Employee> employees)
        {
            DepartmentName = departmentName;
            Employees = employees;
        }
    }
}
