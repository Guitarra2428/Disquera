using Disquera.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Disquera.Models
{
  public  class VistasVM
    {
        public IEnumerable<Album> Listabum { get; set; }

        public IEnumerable<Artista> Listatista { get; set; }


    }
}
