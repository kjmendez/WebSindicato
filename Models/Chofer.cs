using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSindicato.Models
{
    public class Chofer
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(6), MaxLength(10)]
        public string? Ci { get; set; }
        [Required, MinLength(3), MaxLength(30)]
        [Display(Name = "Nombre del Chofer")]
        public string? Name { get; set; }
        public string? Photo { get; set; }
        //To manage photo in an usser interface
        [NotMapped]
        [Display(Name="Cargar Foto")]
        public IFormFile? PhotoFile { get; set; }

        //Relations
        public virtual List<Pago>? Paids { get; set; }
    }
}
