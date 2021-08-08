using Disquera.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Disquera.Models
{
    public class ArtistaVM
    {
        public Artista Artista { get; set; }

        public IEnumerable<SelectListItem> ListaGenero { get; set; }
    }
}
