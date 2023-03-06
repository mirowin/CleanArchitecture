using ExpenceCalculator.Application.Queries;
using ExpenceCalculator.Domain;
using ExpenceCalculator.Domain.DTO;
using ExpenceCalculator.Domain.Entities;

namespace ExpenceCalculator.Application.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        public IEnumerable<T> GetMany();
        public IEnumerable<T> GetMany(Func<T, bool> predicate);
        public T Get(int id);
        public T Get(Func<T, bool> predicate);
        public void Delete(int id);
        public void Update(T entity);
        public void Insert(T entity);
    }
}
