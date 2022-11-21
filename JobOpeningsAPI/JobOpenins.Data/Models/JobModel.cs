using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpenings.Data.Models
{
    public class JobModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string LocationId { get; set; }

        public string DepartmentId { get; set; }
        public string ClosingDate { get; set; }
    }
}
