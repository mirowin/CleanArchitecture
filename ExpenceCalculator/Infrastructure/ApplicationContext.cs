using ExpenceCalculator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenceCalculator.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Operation> Operations { get; }
        public DbSet<Category> Categories { get; }
        public DbSet<OperationDate> OperationDates { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>()
                .HasMany(o => o.Categories)
                .WithMany(c => c.Operations);

            //modelBuilder.Entity<Operation>().Navigation(o => o.Categories).AutoInclude();
            //modelBuilder.Entity<Operation>().Navigation(o => o.OperationDates).AutoInclude();

            modelBuilder.Entity<Category>().HasAlternateKey(u => u.Name);
            
            modelBuilder.Entity<OperationDate>()
                .HasOne(d => d.Operation)
                .WithMany(o => o.OperationDates);
        }

    }
}
