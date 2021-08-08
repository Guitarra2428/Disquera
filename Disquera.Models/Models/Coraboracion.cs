using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Disquera.Models.Models
{
    public class Coraboracion
    {
        public int CoraboracionID { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaCoraboracion { get; set; }

        public ICollection<Artista> ArtistasCoraboracion { get; set; }
        public ICollection<Cancion> CancionsCoraboracion { get; set; }




    }
}
