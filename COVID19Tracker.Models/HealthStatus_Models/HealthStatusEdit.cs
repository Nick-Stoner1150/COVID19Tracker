using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Tracker.Models.HealthStatus_Models
{
    public class HealthStatusEdit
    {
        public int HealthStatusId { get; set; }
        public bool Vaccinated { get; set; }
        public bool HasCovid { get; set; }
        public bool Hospitalized { get; set; }
        public string Comorbidities { get; set; }
        public DateTime QuarantinedDate { get; set; }
        public DateTime LastTestedDate { get; set; }
    }
}
