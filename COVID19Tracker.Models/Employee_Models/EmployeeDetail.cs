using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Tracker.Models.Employee_Models
{
    public class EmployeeDetail
    {
        public int ID { get; set; }
        public int BadgeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int HealthStatusId { get; set; }
        public bool Vaccinated { get; set; }
        public bool HasCovid { get; set; }
        public bool Hospitalized { get; set; }
        public string Comorbities { get; set; }
        public DateTime QuarantinedDate { get; set; }
        public DateTime LastTestedDate { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
    }
}
