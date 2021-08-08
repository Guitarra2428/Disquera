using Disquera.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Disquera.AccesoDatos.Data.Repository.Irepository
{
    public interface IGeneroRepository : IRepository<Genero>
    {
        IEnumerable<SelectListItem> ListaGenero();
        void UPdate(Genero genero);
    }
}
