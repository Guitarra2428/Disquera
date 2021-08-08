using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Disquera.AccesoDatos.Data.Repository.Irepository
{
    public interface IRepository<Enty> where Enty : class
    {
        Enty GetID(int id);

        IEnumerable<Enty> GetAll(
            Expression<Func<Enty, bool>> fiter = null,
            Func<IQueryable<Enty>, IOrderedQueryable<Enty>> OrdeyBy = null,
            string Includepropidad = null
            );
        Enty GetorDefault(
             Expression<Func<Enty, bool>> fiter = null,
            string Includepropidad = null
            );

        void Add(Enty enty);
        void Remove(int id);

        void Remove(Enty enty);

    }
}
