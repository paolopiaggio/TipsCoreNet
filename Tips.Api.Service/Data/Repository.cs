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

        public IQueryable<T> GetAll()
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
            var test = _entities.SingleOrDefault(x=>x.Id == entity.Id);
            if(test != null)
            {
                _context.Entry(test).State = EntityState.Detached;
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public long GetMaxId()
        {
            if (!_entities.Any())
            {
                return 0;
            }
            return _entities.Max(x=>x.Id);
        }
    }
}
