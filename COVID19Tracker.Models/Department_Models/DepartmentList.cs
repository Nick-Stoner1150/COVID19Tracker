using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Tracker.Models.Department_Models
{
    public class DepartmentList
    {
        public string DepartmentName { get; set; }

        public string DepartmentLocation { get; set; }

        public DateTime LastCleanDate { get; set; }
    }
}
