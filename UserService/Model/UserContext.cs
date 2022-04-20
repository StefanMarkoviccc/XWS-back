﻿using Microsoft.EntityFrameworkCore;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer("Server=DESKTOP-BVCUO7A;Database=user;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(_configuration.DatabaseConfiguration.ConnectionString);
        }
    }
}
