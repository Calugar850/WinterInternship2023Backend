using Autumn_Winter_Dev_Bootcamp_2023___Backend.DTOS;
using Autumn_Winter_Dev_Bootcamp_2023___Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Autumn_Winter_Dev_Bootcamp_2023___Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobListingController : ControllerBase
    {
        private JobListingServices jobListingServices;

        public JobListingController(JobListingServices jobListingServices)
        {
            this.jobListingServices = jobListingServices;
        }

        [HttpPost]
        [Route("createJobListing")]
        public IActionResult CreateJobListing(JobListingDTO jobListingDTO)
        {
            int result = jobListingServices.CreateJobListing(jobListingDTO);
            if (result != 0)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError); ;
            }
        }

        [HttpGet]
        [Route("getJobListingFromOneEmployer")]
        public IActionResult GetJobListingFromEmployer(int employerId)
        {
            List<JobListingDTO> result = jobListingServices.GetJobListingFromEmployer(employerId);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError); ;
            }
        }

        [HttpDelete]
        [Route("deleteJobListing")]
        public IActionResult DeleteJobListing(int id)
        {
            List<JobListingDTO> result = jobListingServices.DeleteJobListing(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError); ;
            }
        }
    }
}
