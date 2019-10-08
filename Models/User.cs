using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{

    public class UserSignIn
    {
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(6)]
        public string Password { get; set; }
    }

    public class UserRegistration : UserSignIn
    {
        [Required]
        public string Username { get; set; }
    }

    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        internal string Hash { get; set; }
    }
}