using Disquera.AccesoDatos.Data.Repository.Irepository;
using Disquera.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Disquera.AccesoDatos.Data.Repository
{
    public class GeneroRepository : Repository<Genero>, IGeneroRepository
    {
        private readonly ApplicationDbContext DB;

        public GeneroRepository(ApplicationDbContext context) : base(context)
        {
            DB = context;
        }
        public IEnumerable<SelectListItem> ListaGenero()
        {
            return DB.Generos.Select(g => new SelectListItem()
            {
                Text = g.Nombre,
                Value = g.GeneroID.ToString()
            });
        }

        public void UPdate(Genero genero)
        {
            var objeto = DB.Generos.FirstOrDefault(g => g.GeneroID == genero.GeneroID);
            objeto.Nombre = genero.Nombre;

        }
    }
}
