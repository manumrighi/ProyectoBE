using ProyectoBE.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProyectoBE.Models
{
    public class CreateAndUpdateContactDto
    {
        [Required]
        public string Name { get; set; }
        public int? Number { get; set; }
        public bool? IsDeleted { get; set; }
        public User? User;
        
    }
}
