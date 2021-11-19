using Disquera.Models.Models;
using System.Collections.Generic;

namespace Disquera.Models
{
    public class VistasVM
    {
        public IEnumerable<Album> Listabum { get; set; }

        public IEnumerable<Artista> Listatista { get; set; }


    }
}
