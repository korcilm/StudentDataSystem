using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentDataSystem.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDataSystem.WebUI.DataAccess
{
    public class StudentDataSystemContext:DbContext
    {
        private readonly IConfiguration _configuration;
        public StudentDataSystemContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Personal> Personals { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Role> Roles { get; set; }
        
       
    }
}
