using JobService.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobService.Model
{
    public class JobContext : DbContext
    {
        private static ProjectConfiguration _configuration;
        public JobContext() { }

        public JobContext(DbContextOptions<JobContext> options, ProjectConfiguration configuration) : base(options)
        {
            if (configuration != null)
            {
                _configuration = configuration;
            }
        }

        public DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer("Server=LAPTOP-J9TLUS9E;Database=job;Trusted_Connection=True;");
        }
    }
}