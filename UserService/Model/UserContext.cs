using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Configuration;

namespace UserService.Model
{
    public class UserContext : DbContext
    {
        private static ProjectConfiguration _configuration;
        public UserContext() { }

        public UserContext(DbContextOptions<UserContext> options, ProjectConfiguration configuration) : base(options)
        {
            if (configuration != null)
            {
                _configuration = configuration;
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserFollow> UserFollows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer("Server=mssql;Database=user;User Id=sa;Password=mssql1Ipw;");

            //optionsBuilder.UseSqlServer(_configuration.DatabaseConfiguration.ConnectionString);
        }
    }
}
