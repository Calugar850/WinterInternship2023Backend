using Autumn_Winter_Dev_Bootcamp_2023___Backend.Context;
using Autumn_Winter_Dev_Bootcamp_2023___Backend.DTOS;
using Autumn_Winter_Dev_Bootcamp_2023___Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autumn_Winter_Dev_Bootcamp_2023___Backend.Services
{
    public class EmployerServices
    {
        private EmployerDbContext _employerDbContext;

        public EmployerServices(EmployerDbContext employerDbContext)
        {
            _employerDbContext = employerDbContext;
        }

        public int CreateEmployer(EmployerDTO employerDTO)
        {
            Employer employer = new Employer()
            {
                Name = employerDTO.Name
            };
            _employerDbContext.Employer.Add(employer);
            _employerDbContext.SaveChanges();
           
            return employer.id;
        }


    }
}
