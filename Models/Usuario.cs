using System.ComponentModel.DataAnnotations;
using WebSindicato.Dtos;

namespace WebSindicato.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public RolEnum? Rol { get; set; }
    }
}
