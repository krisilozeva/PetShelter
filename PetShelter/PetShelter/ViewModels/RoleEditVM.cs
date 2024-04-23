using System.ComponentModel.DataAnnotations;

namespace PetShelter.ViewModels
{
    public class RoleEditVM : BaseVM
    {
        [Required]
        public string Name { get; set; }
    }
}
