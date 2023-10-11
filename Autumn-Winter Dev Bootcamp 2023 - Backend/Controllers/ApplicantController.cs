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
    public class ApplicantController : ControllerBase
    {
        private ApplicantServices applicantServices;

        public ApplicantController(ApplicantServices applicantServices)
        {
            this.applicantServices = applicantServices;
        }

        [HttpPost]
        [Route("createApplicant")]
        public IActionResult CreateApplicant(ApplicantDTO applicantDTO)
        {
            int result = applicantServices.CreateApplicant(applicantDTO);
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
        [Route("getAllApplicantsForAnEmployer")]
        public IActionResult GetAllApplicantsForAnEmployer(int employerId)
        {
            List<ApplicantDTO> result = applicantServices.GetAllApplicantsForAnEmployer(employerId);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError); ;
            }
        }

        [HttpGet]
        [Route("getAllApplicantsForAjobListing")]
        public IActionResult GetAllApplicantsForAJobListing(int jobListingId)
        {
            List<ApplicantDTO> result = applicantServices.GetAllApplicantsForAJobListing(jobListingId);
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
