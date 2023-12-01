using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSindicato.Models
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="date")]
        public DateTime PaidDate{ get; set; }
        public int Number { get; set; }
        [Required]
        public int Month { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public decimal Amount { get; set; }

        //Relations, foreign key
        public int IdDriver { get; set; }
        public virtual Chofer? Driver { get; set; }

        public int IdUsser { get; set; }
        public virtual Usuario? Usser { get; set; }
    }
}
