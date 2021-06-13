using ItworksElcenima.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWorks.ELcinema.Data.EF
{
    public class Efrepository<T> : IRepository<T> where T : class

    {
        //public int x { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private readonly EfUniOfWork _uof;
        public Efrepository(EfUniOfWork uof)
        {
            if (uof == null) throw new ArgumentNullException(nameof(uof));
            _uof = uof;
        }
        public IUnitOfWork Uof => _uof; 

        public void Add(T item)
        {
            _uof.Set<T>().Add(item);
        }

        public IQueryable<T> Getall()
        {
            return _uof.Set<T>();
        }

        public void Modify(T item)
        {
            _uof.Entry(item).State=EntityState.Modified;
        }

        public void Remove(T item)
        {
            _uof.Entry(item).State = EntityState.Deleted;
        }
    }
}
