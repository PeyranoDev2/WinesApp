using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class WineAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Wine> Wines { get; set; }

        public DbSet<Tasting> Tastings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasting>()
                .HasMany(t => t.Wines)
                .WithMany(); 
        }

        public WineAppContext(DbContextOptions<WineAppContext> options) : base(options)
        {

        }
    }
}
