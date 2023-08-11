using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPocketAPI.Data.Models
{
    public class PocketDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PocketDetailId { get; set; }
        [Required]
        public int year { get; set; }
        [Required]
        public long PocketId { get; set; }
        [ForeignKey("PocketId")]
        public virtual Pocket Pocket { get; set; }
    }
}
