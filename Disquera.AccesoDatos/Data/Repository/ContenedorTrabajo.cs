using Disquera.AccesoDatos.Data.Repository.Irepository;

namespace Disquera.AccesoDatos.Data.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext DB;
        public ContenedorTrabajo(ApplicationDbContext context)
        {
            DB = context;
            GetGenero = new GeneroRepository(DB);
            GetCancion = new CancionRepository(DB);
            GetArtista = new ArtistaRepository(DB);
            GetAlbum = new AlbumRepository(DB);
        }

        public IGeneroRepository GetGenero { get; private set; }

        public ICancionRepository GetCancion { get; private set; }

        public IAlbumRepository GetAlbum { get; private set; }

        public IArtistaRepository GetArtista { get; private set; }

        public void Dispose()
        {
            DB.Dispose();
        }

        public void Save()
        {
            DB.SaveChanges();
        }
    }
}
