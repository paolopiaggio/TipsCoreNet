using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tips.Model;

namespace Tips.Data
{
    public class TipRepository : IRepository<Tip>
    {
        private static IList<Tip> _tips;

        public TipRepository()
        {
            InitStaticCollection();
        }

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

        private static void InitStaticCollection()
        {
            if (_tips == null)
            {
                _tips = new List<Tip>();
                var lines = File.ReadAllLines(@"Resources/tips.csv");
                foreach (var line in lines)
                {
                    var csvParts = line.Split(',');
                    _tips.Add(new Tip
                    {
                        Id = long.Parse(csvParts[0]),
                        Text = csvParts[1]
                    });
                }
            }
        }
    }
}
