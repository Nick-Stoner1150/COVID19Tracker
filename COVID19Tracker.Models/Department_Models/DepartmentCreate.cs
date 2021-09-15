using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Tracker.Models.DepartmentModel
{
    public class DepartmentCreate
    {
        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }
    }
}
