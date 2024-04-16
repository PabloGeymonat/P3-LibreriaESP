using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace DataAccess
{
    public class Repository<T> : IRepository<T> where T : class, IIdentityById 
    {
        protected DbContext contexto { get; set; }

     
        public T Add(T item)
        {
           contexto.Set<T>().Add(item);
           contexto.SaveChanges();
           return item;
        }

        public void Remove(T item)
        {
            contexto.Set<T>().Remove(item);
            contexto.SaveChanges();
        }

        public void Update(T item)
        {
            contexto.Entry(item).State = EntityState.Modified;
            contexto.SaveChanges();
        }
        
        public virtual T Get(int id)
        {
            T item = contexto.Set<T>().FirstOrDefault(e => e.Id == id);
            return item;
        }
    }
}
