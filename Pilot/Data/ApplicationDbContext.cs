using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pilot.Models;

namespace Pilot.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<CasualEmployee> CasualEmployees { get; set; }
        public DbSet<Employee> Employees { get; set; } 
        public DbSet<ImageModel> Images { get; set; }
        public DbSet<SavedTask> SavedTasks { get; set; }
    }
}
