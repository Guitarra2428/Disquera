using Disquera.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Disquera.AccesoDatos.Data.Repository.Irepository
{
    public interface ICancionRepository : IRepository<Cancion>
    {
        IEnumerable<SelectListItem> ListaCancion();

        void Update(Cancion cancion);
    }
}
