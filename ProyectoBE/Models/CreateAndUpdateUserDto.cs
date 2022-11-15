using System.ComponentModel.DataAnnotations;

namespace ProyectoBE.Models
{
    public class CreateAndUpdateUserDto
    {
        public string Name { get; set; }
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
