using Disquera.AccesoDatos.Data.Repository.Irepository;
using Disquera.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Disquera.AccesoDatos.Data.Repository
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        private readonly ApplicationDbContext DB;

        public AlbumRepository(ApplicationDbContext dB) : base(dB)
        {
            DB = dB;
        }

        public IEnumerable<SelectListItem> ListaAlbum()
        {
            return DB.Albums.Select(AL => new SelectListItem()
            {
                Text = AL.Nombre,
                Value = AL.AlbumID.ToString()
            });
        }

        public void Update(Album album)
        {
            var objeto = DB.Albums.FirstOrDefault(al => al.AlbumID == album.AlbumID);
            objeto.Nombre = album.Nombre;
            objeto.FechaLanzamiento = album.FechaLanzamiento;
            objeto.UrlImagen = album.UrlImagen;

        }
    }
}
