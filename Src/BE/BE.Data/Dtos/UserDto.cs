using System.ComponentModel.DataAnnotations;

namespace BE.Data.Dtos
{
    public class UserDto
    {
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 1, ErrorMessage = "Invalid username")]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool Active { get; set; }       
    }
}
