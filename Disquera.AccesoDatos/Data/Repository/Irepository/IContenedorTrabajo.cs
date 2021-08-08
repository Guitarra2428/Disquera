using System;

namespace Disquera.AccesoDatos.Data.Repository.Irepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        IGeneroRepository GetGenero { get; }
        ICancionRepository GetCancion { get; }
        IAlbumRepository GetAlbum { get; }
        IArtistaRepository GetArtista { get; }
        void Save();

    }
}
