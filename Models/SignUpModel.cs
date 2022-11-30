using System.ComponentModel.DataAnnotations;

namespace ToDoWebAPI.Models
{
    public class SignUpModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [Compare("ComfirmPassword")]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

    }
}
