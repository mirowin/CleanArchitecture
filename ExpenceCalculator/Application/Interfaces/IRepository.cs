using ExpenceCalculator.Application.Queries;
using ExpenceCalculator.Domain;
using ExpenceCalculator.Domain.DTO;
using ExpenceCalculator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenceCalculator.Application.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        public IEnumerable<T> Get(GetOperationsQuery query);
        public T Get(int id);
        public void Delete(int id);
        public void Update(T entity);
        public void Insert(T entity);
    }
}
