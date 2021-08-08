using Disquera.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Disquera.AccesoDatos.Data.Repository.Irepository
{
    public interface IAlbumRepository : IRepository<Album>
    {

        IEnumerable<SelectListItem> ListaAlbum();

        void Update(Album album);
    }
}
