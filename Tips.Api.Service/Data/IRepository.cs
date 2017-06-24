using System.Collections.Generic;
using System.Linq;
using Tips.Model;

namespace Tips.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable <T> GetAll();
        T Get(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        long GetMaxId();
    }
}
