using System.ComponentModel.DataAnnotations;

namespace RegApp.Models
{
    public class UserModel
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string name { get; set; } 

        [Required]
        [EmailAddress]
        public string email { get; set; } 

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; } 
    }
}
