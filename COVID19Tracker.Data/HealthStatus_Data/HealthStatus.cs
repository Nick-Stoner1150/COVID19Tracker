    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Tracker.Data.HealthStatus_Data
{
    public class HealthStatus
    {
        [Key]
        public int HealthStatusId { get; set; }

        [Required]
        public bool Vaccinated { get; set; }

        [Required]
        public bool HasCovid { get; set; }

        [Required]
        public bool Hospitalized { get; set; }

        [Required]
        public string Comorbidities { get; set; }

        public DateTime QuarantinedDate { get; set; }

        public DateTime LastTestedDate { get; set; }
    }
}
