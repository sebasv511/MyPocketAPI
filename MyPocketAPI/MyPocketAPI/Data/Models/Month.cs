using MyPocketAPI.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPocketAPI.Data.Models
{
    public class Month
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MonthId { get; set; }
        [Required]
        public AbreviatedMonth MonthNumber { get; set; }
        [Required]
        public long PocketDetailId { get; set; }
        [ForeignKey("PocketDetailId")]
        public virtual PocketDetail PocketDetail { get; set; }
    }
}
