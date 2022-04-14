using Microsoft.EntityFrameworkCore;
using PostService.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Model
{
    public class PostContext : DbContext
    {
        private static ProjectConfiguration _configuration;
        public PostContext() { }

        public PostContext(DbContextOptions<PostContext> options, ProjectConfiguration configuration) : base(options)
        {
            if (configuration != null)
            {
                _configuration = configuration;
            }
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer(_configuration.DatabaseConfiguration.ConnectionString);
        }
    }
        
}

