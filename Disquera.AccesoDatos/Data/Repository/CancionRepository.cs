using Disquera.AccesoDatos.Data.Repository.Irepository;
using Disquera.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Disquera.AccesoDatos.Data.Repository
{
    public class CancionRepository : Repository<Cancion>, ICancionRepository
    {

        private readonly ApplicationDbContext DB;

        public CancionRepository(ApplicationDbContext dB) : base(dB)
        {
            DB = dB;
        }

        public IEnumerable<SelectListItem> ListaCancion()
        {
            return DB.Cancions.Select(c => new SelectListItem()
            {
                Text = c.Tema,
                Value = c.CancionID.ToString()

            });
        }

        public void Update(Cancion cancion)
        {
            var objeto = DB.Cancions.FirstOrDefault(c => c.CancionID == cancion.CancionID);
            objeto.Tema = cancion.Tema;
            objeto.TiempoReproducion = cancion.TiempoReproducion;
            objeto.FechaCreacion = cancion.FechaCreacion;
            objeto.CancionID = cancion.CancionID;


        }
    }
}
