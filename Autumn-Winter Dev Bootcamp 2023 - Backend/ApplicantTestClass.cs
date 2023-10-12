using Autumn_Winter_Dev_Bootcamp_2023___Backend.DTOS;
using Autumn_Winter_Dev_Bootcamp_2023___Backend.Models;
using Autumn_Winter_Dev_Bootcamp_2023___Backend.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autumn_Winter_Dev_Bootcamp_2023___Backend
{
    [TestClass]
    public class ApplicantTestClass
    {

        [TestMethod]
        public void Apply_WithValidApplicant_ShouldReturnTrue()
        {
            ApplicantServices applicantServices = new ApplicantServices();
            ApplicantDTO validApplicant = new ApplicantDTO()
            {
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "0754123698",
                Email = "johndoe@gmail.com",
                AddressLine1 = "Romania",
                AddressLine2 = "Iasi, Str, Mircea Eliade",
                Country = 0,
                State = "Iasi",
                City = 0,
                JobListingId = 1
            };
            int result = applicantServices.CreateApplicant(validApplicant);
            Assert.AreNotEqual(0, result);
        }
    }
}
