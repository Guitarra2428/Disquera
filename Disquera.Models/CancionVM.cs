using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Disquera.Models.Models
{
    public class CancionVM
    {
        public Cancion Cancion { get; set; }

        public IEnumerable<SelectListItem> ListaAlbum { get; set; }
    }
}
