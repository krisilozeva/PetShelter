using PetShelter.Data.Entities;

namespace PetShelter.ViewModels
{
    public class RoleDetailsVM : BaseVM
    {
        public string Name { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual List<Pet> Pets { get; set; }
    }
}
