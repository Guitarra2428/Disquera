using Disquera.AccesoDatos.Data.Repository.Irepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Disquera.AccesoDatos.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext applicationDb;
        internal readonly DbSet<T> dbset;

        public Repository(DbContext context)
        {
            applicationDb = context;
            dbset = context.Set<T>();
        }
        public void Add(T enty)
        {
            dbset.Add(enty);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> fiter = null, Func<IQueryable<T>, IOrderedQueryable<T>> OrdeyBy = null, string Includepropidad = null)
        {
            IQueryable<T> Querys = dbset;

            if (fiter != null)
            {
                Querys = Querys.Where(fiter);
            }

            if (Includepropidad != null)
            {
                foreach (var proquery in Includepropidad.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    Querys = Querys.Include(proquery);
                }
            }
            if (OrdeyBy != null)
            {
                return OrdeyBy(Querys).ToList();
            }
            return Querys.ToList();

        }

        public T GetID(int id)
        {
            return dbset.Find(id);
        }

        public T GetorDefault(Expression<Func<T, bool>> fiter = null, string Includepropidad = null)
        {
            IQueryable<T> Querys = dbset;

            if (fiter != null)
            {
                Querys = Querys.Where(fiter);
            }

            if (Includepropidad != null)
            {
                foreach (var proquery in Includepropidad.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    Querys = Querys.Include(proquery);
                }
            }
            return Querys.FirstOrDefault();
        }

        public void Remove(int id)
        {
            T Elimina = dbset.Find(id);
            Remove(Elimina);

        }

        public void Remove(T enty)
        {
            dbset.Remove(enty);
        }
    }
}
