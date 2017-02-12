using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public Tip Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tip> GetAll()
        {
            return _tips;
        }

        public void Insert(Tip entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Tip entity)
        {
            throw new NotImplementedException();
        }
    }
}