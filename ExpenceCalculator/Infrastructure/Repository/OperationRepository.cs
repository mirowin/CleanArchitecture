using ExpenceCalculator.Application.Interfaces;
using ExpenceCalculator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenceCalculator.Infrastructure.Repository
{
    public class OperationRepository : BaseGenericRepository<Operation>
    {
        private DbContext context;
        private DbSet<Operation> dbSet;

        public OperationRepository(DbContext dbContext) : base(dbContext)
        {
            this.context = dbContext;
            this.dbSet = context.Set<Operation>();
        }

        public override Operation Get(int id)
        {
            return dbSet.Include(x => x.Categories).Include(x => x.OperationDates).First(o => o.Id == id);
        }

        public override IEnumerable<Operation> GetMany()
        {
            return dbSet.Include(x => x.Categories).Include(x => x.OperationDates);
        }

        public override IEnumerable<Operation> GetMany(Func<Operation, bool> predicate)
        {
            return dbSet.Include(x => x.Categories).Include(x => x.OperationDates).Where(predicate);
        }

        public override Operation Get(Func<Operation, bool> predicate)
        {
            return dbSet.Include(x => x.Categories).Include(x => x.OperationDates).FirstOrDefault(predicate);
        }
    }
}
