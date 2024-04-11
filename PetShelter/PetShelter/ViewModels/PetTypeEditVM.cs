using System.ComponentModel.DataAnnotations;

namespace PetShelter.ViewModels
{
    public class PetTypeEditVM
    {
        [Required]
        public string Name { get; set; }
    }
}
