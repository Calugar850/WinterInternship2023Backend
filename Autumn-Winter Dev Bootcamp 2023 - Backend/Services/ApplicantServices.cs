using Autumn_Winter_Dev_Bootcamp_2023___Backend.Context;
using Autumn_Winter_Dev_Bootcamp_2023___Backend.DTOS;
using Autumn_Winter_Dev_Bootcamp_2023___Backend.Enums;
using Autumn_Winter_Dev_Bootcamp_2023___Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Autumn_Winter_Dev_Bootcamp_2023___Backend.Services
{
    public class ApplicantServices
    {
        private ApplicantDbContext _applicantDbContext;
        private JobListingDbContext _jobListingDbContext;

        public ApplicantServices(ApplicantDbContext applicantDbContext, JobListingDbContext jobListingDbContext)
        {
            _applicantDbContext = applicantDbContext;
            _jobListingDbContext = jobListingDbContext;
        }

        public int CreateApplicant(ApplicantDTO applicantDTO)
        {
            JobListing existingJobListing = _jobListingDbContext.JobListing.Find(applicantDTO.JobListingId);
            
            string phoneNumberPattern = @"^\d{10}$";
            Regex phoneNumberRegex = new Regex(phoneNumberPattern);
            bool validPhoneNumber = phoneNumberRegex.IsMatch(applicantDTO.PhoneNumber);

            string emailPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
            Regex emailRegex = new Regex(emailPattern);
            bool validEmail = emailRegex.IsMatch(applicantDTO.Email);
            if (existingJobListing == null || !validEmail || !validPhoneNumber)
            {
                return 0;
            }
            if (applicantDTO.Country!= Country.Romania && applicantDTO.Country!= Country.Bulgaria && applicantDTO.Country!= Country.Greece)
            {
                return 0;
            }
            if (applicantDTO.Country == Country.Romania && (applicantDTO.City!= City.Bucharest && applicantDTO.City != City.Iasi && applicantDTO.City != City.Cluj))
            {
                return 0;
            }

            Applicant applicant = new Applicant()
            {
                FirstName = applicantDTO.FirstName,
                LastName = applicantDTO.LastName,
                PhoneNumber = applicantDTO.PhoneNumber,
                Email = applicantDTO.Email,
                AddressLine1 = applicantDTO.AddressLine1,
                AddressLine2 = applicantDTO.AddressLine2,
                Country = applicantDTO.Country,
                State = applicantDTO.State,
                City = applicantDTO.City,
                JobListingId = applicantDTO.JobListingId
            };
            _applicantDbContext.Applicant.Add(applicant);
            _applicantDbContext.SaveChanges();
            return applicant.id;
        }

        public List<ApplicantDTO> GetAllApplicantsForAnEmployer(int employerId)
        {
            List<ApplicantDTO> applicantDTOs = new List<ApplicantDTO>();
            List<JobListing> jobListings = _jobListingDbContext.JobListing.Where(j => j.EmployerId == employerId).ToList();
            foreach(JobListing job in jobListings)
            {
                List<Applicant> applicantDTOs2 = _applicantDbContext.Applicant.Where(j => j.JobListingId == job.id).ToList();
                applicantDTOs.AddRange(applicantDTOs2.Select(applicant => new ApplicantDTO
                {
                    id = applicant.id,
                    FirstName = applicant.FirstName,
                    LastName = applicant.LastName,
                    PhoneNumber = applicant.PhoneNumber,
                    Email = applicant.Email,
                    AddressLine1 = applicant.AddressLine1,
                    AddressLine2 = applicant.AddressLine2,
                    Country = applicant.Country,
                    State = applicant.State,
                    City = applicant.City,
                    JobListingId = applicant.JobListingId
                }).ToList());
            }
            return applicantDTOs;
        }

        public List<ApplicantDTO> GetAllApplicantsForAJobListing(int jobListingId)
        {
            List<Applicant> applicants = _applicantDbContext.Applicant.Where(j => j.JobListingId == jobListingId).ToList();

            List<ApplicantDTO> applicantDTOs = applicants.Select(applicant=> new ApplicantDTO
            {
                id = applicant.id,
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                PhoneNumber = applicant.PhoneNumber,
                Email = applicant.Email,
                AddressLine1 = applicant.AddressLine1,
                AddressLine2 = applicant.AddressLine2,
                Country = applicant.Country,
                State = applicant.State,
                City = applicant.City,
                JobListingId = applicant.JobListingId
            }).ToList(); ;
            return applicantDTOs;
        }
    }
}
