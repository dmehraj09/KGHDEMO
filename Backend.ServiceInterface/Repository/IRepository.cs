using Backend.ServiceInterface.Models;
using System.Collections.Generic;
using System.Linq;

namespace Backend.ServiceInterface.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {

        IEnumerable<T> Get();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
        void CreateTransaction();
        void Commit();
        void Rollback();
        IQueryable<T> Table { get; }
    }
}
