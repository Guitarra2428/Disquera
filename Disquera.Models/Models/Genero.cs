using System.ComponentModel.DataAnnotations;

namespace Disquera.Models.Models
{
    public class Genero
    {
        [Key]
        public int GeneroID { get; set; }
        [Required(ErrorMessage = "Este Campo Es Obligatorio")]
        public string Nombre { get; set; }


    }
}
