using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using note_main_backend.Models;
namespace note_main_backend.Data
{
    public class NoteDBContext : DbContext
    {
        private IConfiguration _config;

        public NoteDBContext(IConfiguration configuration)
        {
            _config = configuration;
        }

        public DbSet<LogEntry> Logs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(_config.GetConnectionString("DB"), new MySqlServerVersion(new Version("8.0")));
            }
        }




    }
}
