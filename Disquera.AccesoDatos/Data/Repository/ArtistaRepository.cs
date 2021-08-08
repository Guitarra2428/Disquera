using Disquera.AccesoDatos.Data.Repository.Irepository;
using Disquera.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Disquera.AccesoDatos.Data.Repository
{
    public class ArtistaRepository : Repository<Artista>, IArtistaRepository
    {
        private readonly ApplicationDbContext DB;

        public ArtistaRepository(ApplicationDbContext dB) : base(dB)
        {
            DB = dB;
        }

        public IEnumerable<SelectListItem> ListaArtista()
        {
            return DB.Artistas.Select(A => new SelectListItem()
            {
                Text = A.Nombre,
                Value = A.ArtistaID.ToString()

            });
        }

        public void Update(Artista artista)
        {
            var objeto = DB.Artistas.FirstOrDefault(a => a.ArtistaID == artista.ArtistaID);
            objeto.Nombre = artista.Nombre;
            objeto.Apellido = artista.Apellido;
            objeto.Descripcion = artista.Descripcion;
            objeto.Sexo = artista.Sexo;
            objeto.FechaNacimiento = artista.FechaNacimiento;
            objeto.UrlImagen = artista.UrlImagen;
            // objeto.Nombre = artista.Nombre;



        }
    }
}
