using System.ComponentModel.DataAnnotations;
using WebSindicato.Dtos;

namespace WebSindicato.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string? Email { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string? Password { get; set; }
        [Required, MinLength(5), MaxLength(30)]
        public string Nombre { get; set; }
        [Required]
        public RolEnum? Rol { get; set; }

        //Relations
        public virtual List<Pago>? Paids { get; set; }
    }
}
