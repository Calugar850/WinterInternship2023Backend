using Autumn_Winter_Dev_Bootcamp_2023___Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autumn_Winter_Dev_Bootcamp_2023___Backend.Context
{
    public class EmployerDbContext : DbContext
    {
        public EmployerDbContext(DbContextOptions<EmployerDbContext> options): base(options)
        {
        }

        public DbSet<Employer> Employer { get; set; }
    }
}
