using MyPocketAPI.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPocketAPI.Data.Models
{
    public class Movement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MovementId { get; set; }
        [Required]
        public MovementType Type { get; set; }
        [Required]
        public string Concept { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal Cost { get; set; }
        [Required]
        public DateTime Payday { get; set; }
        [Required]
        public DateTime PaydayLimit { get; set; }
        [Required]
        public MovementStatus State { get; set; }
        [Required]
        public long MonthDetailId { get; set; }
        [ForeignKey("MonthDetailId")]
        public virtual MonthDetail MonthDetail { get; set; }
    }
}
