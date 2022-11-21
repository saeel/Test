using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpenings.Data.Models
{
    public class JobDtlModel
    {
        public string Job_Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public string PostedDate { get; set; }
        public string ClosingDate { get; set; }
    }
}
