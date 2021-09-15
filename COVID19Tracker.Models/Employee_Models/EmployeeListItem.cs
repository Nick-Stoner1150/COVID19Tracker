using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Tracker.Models.Employee_Models
{
    public class EmployeeListItem
    {
        public int ID { get; set; }
        public int BadgeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }
        public int HealthStatusId { get; set; }
    }
}
