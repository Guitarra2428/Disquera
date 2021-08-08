using Disquera.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Disquera.Models
{
    public class AlbumVM
    {
        public Album Album { get; set; }

        public IEnumerable<SelectListItem> ListaArtista { get; set; }

        public IEnumerable<SelectListItem> ListaCancion { get; set; }

    }
}
