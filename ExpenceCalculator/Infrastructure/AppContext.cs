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

        }

        public DbSet<Operation> Operations { get; }
        public DbSet<OperationGroup> OperationGroups { get; }
        public DbSet<OperationDate> operationDates { get; }
    }
}
