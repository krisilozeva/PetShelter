
using PetShelter.Data.Entities;

namespace PetShelter.ViewModels
{
    public class ShelterDetailsVM : BaseVM
    {
        public ShelterDetailsVM() 
        { 
            this.Pets = new List<PetDetailsVM>();
            this.Employees = new List<UserDetailsVM>();
        }
        public int PetCapacity { get; set; }
        public int LocationId { get; set; }
        public  LocationDetailsVM Location { get; set; }
        public virtual List<UserDetailsVM> Employees { get; set; }
        public virtual List<PetDetailsVM> Pets { get; set; }
    }
}
