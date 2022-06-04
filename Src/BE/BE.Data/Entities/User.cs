using BE.Data.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace BE.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field with name {0} is required")]
        [StringLength(15, ErrorMessage = "Invalid name length")]
        [FirstLetterUppercase]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field with surname {0} is required")]
        [FirstLetterUppercase]
        [StringLength(30, ErrorMessage = "Invalid surname length")]
        public string Surname { get; set; }

        [StringLength(15, ErrorMessage = "Invalid username")]
        [Required(ErrorMessage = "The field with username {0} is required")]
        public string Username { get; set; }

        [StringLength(120, ErrorMessage = "Invalid password")]
        [Required(ErrorMessage = "The field with password {0} is required")]
        public string HashedPassword { get; set; }
    }
}
