using System.ComponentModel.DataAnnotations;

namespace ProyectoBE.Models
{
    public class AuthenticationRequestBody
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
