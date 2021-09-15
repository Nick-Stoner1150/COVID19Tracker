using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Tracker.Models.Employee_Models
{
    public class EmployeeCreate
    {
        [Required]
        public int BadgeId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public int HealthStatusId { get; set; }

    }
}
