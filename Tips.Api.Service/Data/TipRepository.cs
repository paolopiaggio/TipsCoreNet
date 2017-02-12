using System;
using System.Collections.Generic;
using System.Linq;
using Tips.Model;

namespace Tips.Data
{
    public class TipRepository : IRepository<Tip>
    {
        private readonly IList<Tip> _tips = new List<Tip>
        {
            new Tip { Id=1, Text="maybe I Work"},
            new Tip { Id=2, Text="maybe I Work 2"},
        };

        public void Delete(Tip entity)
        {
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }
            _tips.Remove(entity);
        }

        public Tip Get(long id)
        {
            return _tips.SingleOrDefault(x=>x.Id == id);
        }

        public IEnumerable<Tip> GetAll()
        {
            return _tips;
        }

        public void Insert(Tip entity)
        {
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }
            _tips.Add(entity);
        }

        public void Update(Tip entity)
        {
            if (entity == null) {
                throw new ArgumentNullException("entity");
            }
            var entityToRemove = _tips.SingleOrDefault(x=>x.Id == entity.Id);
            if(entityToRemove == null) {
                throw new InvalidOperationException("entity not found, impossible to update");
            }
            _tips.Remove(entityToRemove);
            _tips.Add(entity);
        }
    }
}
