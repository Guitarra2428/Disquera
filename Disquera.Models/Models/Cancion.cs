using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disquera.Models.Models
{
    public class Cancion
    {
        [Key]
        public int CancionID { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        public String Tema { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        public int TiempoReproducion { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }


        public int AlbumID { get; set; }
        [ForeignKey("AlbumID")]
        public Album Album { get; set; }









    }
}
