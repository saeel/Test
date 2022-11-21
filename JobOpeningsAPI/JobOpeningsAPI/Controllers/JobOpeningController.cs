using JobOpenings.Data.Models;
using JobOpenins.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobOpeningsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOpeningController : ControllerBase
    {
        private readonly IJobOpenings _jobOpeningsRepository;

        public JobOpeningController(IJobOpenings jobOpeningsRepository)
        {
            _jobOpeningsRepository = jobOpeningsRepository;
        }

        [HttpPost]
        [Route("Jobs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> InsertJobs(JobModel lstJobs)
        {
            var data = _jobOpeningsRepository.InsertJobs(lstJobs);
            return Ok(data);
        }

        [HttpPut]
        [Route("Jobs/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateJobs(JobModel lstJobs,int Id)
        {
            var data = _jobOpeningsRepository.UpdateJobs(lstJobs,Id);
            return Ok(data);
        }

        [HttpPost]
        [Route("GetJobList/list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<JobDtlModel>> GetJobList(SendJobModel lstJobs)
        {
            return (List<JobDtlModel>)await _jobOpeningsRepository.GetJobList(lstJobs);
        }

        [HttpGet]
        [Route("GetJobDetails/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<GetJobDtlModel>> GetJobDetails(int Id)
        {
            return (List<GetJobDtlModel>)await _jobOpeningsRepository.GetJobDetails(Id);
        }

    }
}
