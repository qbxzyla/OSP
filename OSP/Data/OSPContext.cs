using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OSP.Models;

namespace OSP.Data
{
    public class OSPContext : DbContext
    {
        public OSPContext (DbContextOptions<OSPContext> options)
            : base(options)
        {
        }

        public DbSet<OSP.Models.Firefighter> Firefighter { get; set; } = default!;

        public DbSet<OSP.Models.Drive>? Drive { get; set; }

        public DbSet<OSP.Models.Incident>? Incident { get; set; }

        public DbSet<OSP.Models.Car>? Car { get; set; }

        public DbSet<OSP.Models.CarInAction>? CarInAction { get; set; }
    }
}
