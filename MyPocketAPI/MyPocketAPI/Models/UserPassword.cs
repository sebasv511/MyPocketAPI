using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPocketAPI.Models
{
    public class UserPassword
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public long IdUser { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime LastChangeDate { get; set; }
    }
}
