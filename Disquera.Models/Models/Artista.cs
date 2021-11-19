using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Disquera.Models.Models
{
    public class Artista
    {
        [Key]
        public int ArtistaID { get; set; }


        [Required(ErrorMessage = "Este Campo Es Obligatorio")]

        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]

        public string Apellido { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]

        public String Descripcion { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        public Char Sexo { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public String UrlImagen { get; set; }

        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }


        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        public int GeneroID { get; set; }

        [ForeignKey("GeneroID")]
        public virtual Genero Genero { get; set; }




    }


}
