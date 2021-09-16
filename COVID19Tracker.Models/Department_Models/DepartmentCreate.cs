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
        public string DepartmentName { get; set; }

        public string DepartmentLocation { get; set; }                
        
    }
}
