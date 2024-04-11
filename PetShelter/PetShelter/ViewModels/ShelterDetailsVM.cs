
using PetShelter.Data.Entities;

namespace PetShelter.ViewModels
{
    public class ShelterDetailsVM : BaseVM
    {
        public int PetCapacity { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public virtual List<User> Employees { get; set; }
        public virtual List<Pet> Pets { get; set; }
    }
}
