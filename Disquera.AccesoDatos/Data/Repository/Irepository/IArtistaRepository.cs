using Disquera.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Disquera.AccesoDatos.Data.Repository.Irepository
{
    public interface IArtistaRepository : IRepository<Artista>
    {
        IEnumerable<SelectListItem> ListaArtista();

        void Update(Artista artista);
    }
}
