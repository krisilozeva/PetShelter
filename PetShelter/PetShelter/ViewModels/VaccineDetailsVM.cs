using PetShelter.Data.Entities;

namespace PetShelter.ViewModels
{
    public class VaccineDetailsVM : BaseVM
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual List<PetVaccine> PetVaccines { get; set; }
        public virtual List<Pet> Pets { get; set; }

    }
}