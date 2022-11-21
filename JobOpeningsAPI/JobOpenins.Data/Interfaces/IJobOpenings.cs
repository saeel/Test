using JobOpenings.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOpenins.Data.Interfaces
{
    public interface IJobOpenings
    {
        Task<bool> InsertJobs(JobModel lstJobs);
        Task<bool> UpdateJobs(JobModel lstJobs, int id);
        Task<List<JobDtlModel>> GetJobList(SendJobModel lstJobs);
        Task<List<GetJobDtlModel>> GetJobDetails(int id);
    }
}
