using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Autumn_Winter_Dev_Bootcamp_2023___Backend.Models
{
    public class JobListing
    {
        [Key]
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        [ForeignKey("EmployerId")]
        public int EmployerId { get; set; }
    }
}
