using System.ComponentModel.DataAnnotations;

namespace ObaOba.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Name {get;set;}
        [Required]
        public string LastName {get;set;}
        [Required]
        public string Email {get;set;}
        [Required]
        [StringLength(15, MinimumLength = 7, ErrorMessage = "You must specify a password between 7 and 15 characters")]
        public string Password {get;set;}
    }
}