using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Autumn_Winter_Dev_Bootcamp_2023___Backend.Models
{
    public class Employer
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
    }
}
