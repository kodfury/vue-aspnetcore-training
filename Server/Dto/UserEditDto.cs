using System.ComponentModel.DataAnnotations;

namespace Server.Dto
{
    public class UserEditDto
    {
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(12, MinimumLength = 4)]
        public string Password { get; set; }
    }
}