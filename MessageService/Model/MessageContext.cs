using MessageService.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageService.Model
{
    public class MessageContext : DbContext
    {
        private static ProjectConfiguration _configuration;
        public MessageContext() { }

        public MessageContext(DbContextOptions<MessageContext> options, ProjectConfiguration configuration) : base(options)
        {
            if (configuration != null)
            {
                _configuration = configuration;
            }
        }

        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer("Server=DESKTOP-BVCUO7A;Database=message;Trusted_Connection=True;");
        }
    }
}