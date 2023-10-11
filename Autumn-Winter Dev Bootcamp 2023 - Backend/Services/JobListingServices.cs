using Autumn_Winter_Dev_Bootcamp_2023___Backend.Context;
using Autumn_Winter_Dev_Bootcamp_2023___Backend.DTOS;
using Autumn_Winter_Dev_Bootcamp_2023___Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autumn_Winter_Dev_Bootcamp_2023___Backend.Services
{
    public class JobListingServices
    {
        private JobListingDbContext _jobListingDbContext;
        private EmployerDbContext _employerDbContext;

        public JobListingServices(JobListingDbContext jobListingDbContext, EmployerDbContext employerDbContext)
        {
            _jobListingDbContext = jobListingDbContext;
            _employerDbContext = employerDbContext;
        }

        public int CreateJobListing(JobListingDTO jobListingDTO)
        {
            Employer existingEmployer = _employerDbContext.Employer.Find(jobListingDTO.EmployerId);
            if (jobListingDTO.Salary < 0 || existingEmployer == null)
            {
                return 0;
            }
            JobListing jobListing = new JobListing()
            {
                Title = jobListingDTO.Title,
                Description = jobListingDTO.Description,
                Salary = jobListingDTO.Salary,
                EmployerId = jobListingDTO.EmployerId
            };
            _jobListingDbContext.JobListing.Add(jobListing);
            _jobListingDbContext.SaveChanges();
            return jobListing.id;
        }

        public List<JobListingDTO> GetJobListingFromEmployer(int id)
        {
            List<JobListing> jobListings = _jobListingDbContext.JobListing.Where(j => j.EmployerId == id).ToList();
            List<JobListingDTO> jobListingDTOs = jobListings.Select(jobListing => new JobListingDTO {
                id = jobListing.id,
                Title = jobListing.Title,
                Description = jobListing.Description,
                Salary = jobListing.Salary,
                EmployerId = jobListing.EmployerId
            }).ToList(); ;
            return jobListingDTOs;
        }

        public List<JobListingDTO> DeleteJobListing(int id)
        {
            JobListing job= _jobListingDbContext.JobListing.First(j => j.id == id);
            _jobListingDbContext.JobListing.Remove(job);
            _jobListingDbContext.SaveChanges();
            List<JobListing> jobListings = _jobListingDbContext.JobListing.ToList();
            List<JobListingDTO> jobListingDTOs = jobListings.Select(jobListing => new JobListingDTO
            {
                id = jobListing.id,
                Title = jobListing.Title,
                Description = jobListing.Description,
                Salary = jobListing.Salary,
                EmployerId = jobListing.EmployerId
            }).ToList(); ;
            return jobListingDTOs;
        }

    }
}
