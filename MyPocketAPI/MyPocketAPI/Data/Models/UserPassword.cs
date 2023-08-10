using MyPocketAPI.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPocketAPI.Data.Models
{
    public class UserPassword
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }        
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime LastChangeDate { get; set; }
        [Required]
        public PasswordState State { get; set; }
        public long IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }
    }
}
