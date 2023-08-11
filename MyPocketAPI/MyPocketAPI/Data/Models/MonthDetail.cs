using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPocketAPI.Data.Models
{
    public class MonthDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MonthDetailId { get; set; }
        [Required]
        public int Period { get; set; }
        [Required]
        public long MonthId { get; set; }
        [ForeignKey("MonthId")]
        public virtual Month Month { get; set; }
    }
}
