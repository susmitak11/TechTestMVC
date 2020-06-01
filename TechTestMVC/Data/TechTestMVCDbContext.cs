using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechTestMVC.Models;

namespace TechTestMVC.Data
{
    public class TechTestMVCDbContext : DbContext
    {
        public TechTestMVCDbContext (DbContextOptions<TechTestMVCDbContext> options)
            : base(options)
        {
        }

        public DbSet<TechTestMVC.Models.Technology> Technology { get; set; }

        public DbSet<TechTestMVC.Models.Attendee> Attendee { get; set; }
    }
}
