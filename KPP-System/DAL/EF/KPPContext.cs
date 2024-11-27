using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class KPPContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Pass> Passes { get; set; }
        public DbSet<Zone> Zones { get; set; }
        public KPPContext(DbContextOptions options) : base(options) { }
    }
}
