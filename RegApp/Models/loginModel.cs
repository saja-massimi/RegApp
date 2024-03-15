using System.ComponentModel.DataAnnotations;


namespace RegApp.Models
{
    public class loginModel
    {
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }


    }
}
