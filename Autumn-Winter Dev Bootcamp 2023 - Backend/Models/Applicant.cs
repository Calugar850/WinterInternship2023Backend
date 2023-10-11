using Autumn_Winter_Dev_Bootcamp_2023___Backend.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Autumn_Winter_Dev_Bootcamp_2023___Backend.Models
{
    public class Applicant
    {
        [Key]
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public Country Country { get; set; }
        public string State { get; set; }
        public City City { get; set; }
        [ForeignKey("JobListingId")]
        public int JobListingId { get; set; }
    }
}
