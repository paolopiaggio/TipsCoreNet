using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tips.Model;

namespace Tips.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApiContext _context;
        private DbSet<T> _entities;

        public Repository(ApiContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public void Delete(T entity)
        {
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public T Get(long id)
        {
            return _entities.SingleOrDefault(x=>x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities;
        }

        public void Insert(T entity)
        {
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }
            _context.SaveChanges();
        }
    }
}
