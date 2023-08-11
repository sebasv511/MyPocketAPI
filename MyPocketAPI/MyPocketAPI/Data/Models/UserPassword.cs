using MyPocketAPI.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPocketAPI.Data.Models
{
    public class UserPassword
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserPasswordId { get; set; }        
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime LastChangeDate { get; set; }
        [Required]
        public PasswordState State { get; set; }
        [Required]
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
