using Autumn_Winter_Dev_Bootcamp_2023___Backend.DTOS;
using Autumn_Winter_Dev_Bootcamp_2023___Backend.Models;
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
    public class EmployerController : ControllerBase
    {
        private EmployerServices employerServices;

        public EmployerController(EmployerServices employerServices)
        {
            this.employerServices = employerServices;
        }

        [HttpPost]
        [Route("createEmployer")]
        public IActionResult CreateEmployer(EmployerDTO employerDTO)
        {
            int result = employerServices.CreateEmployer(employerDTO);
            if (result != 0)
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
