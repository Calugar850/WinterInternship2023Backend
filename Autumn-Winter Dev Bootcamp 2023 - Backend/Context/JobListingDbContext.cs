using Autumn_Winter_Dev_Bootcamp_2023___Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autumn_Winter_Dev_Bootcamp_2023___Backend.Context
{
    public class JobListingDbContext : DbContext
    {
        public JobListingDbContext(DbContextOptions<JobListingDbContext> options) : base(options)
        {
        }

        public DbSet<JobListing> JobListing { get; set; }
    }
}
