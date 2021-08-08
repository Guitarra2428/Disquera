using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disquera.Models.Models
{
    public class Album
    {
        [Key]
        public int AlbumID { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        public String Nombre { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public String UrlImagen { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaLanzamiento { get; set; }


        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        public int ArtistaID { get; set; }
        [ForeignKey("ArtistaID")]
        public virtual Artista Artista { get; set; }

       



    }
}
