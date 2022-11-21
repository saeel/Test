using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpenings.Data.Models
{
    public class GetJobDtlModel
    {
        public GetJobDtlModel()
        {
            Location = new List<Location>();
            Department = new List<Department>();
        }
        public string Job_Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Location> Location { get; set; }
        public List<Department> Department { get; set; }
        public string PostedDate { get; set; }
        public string ClosingDate { get; set; }
    }

    public class Location
    {
        public string Job_Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
    }

    public class Department
    {
        public string Job_Id { get; set; }
        public string Title { get; set; }
    }
}
