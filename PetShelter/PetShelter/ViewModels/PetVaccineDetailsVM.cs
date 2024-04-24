using PetShelter.Data.Entities;

namespace PetShelter.ViewModels
{
    public class PetVaccineDetailsVM : BaseVM
    {
        public int PetId { get; set; }
        public virtual Pet Pet { get; set; }
        public int VaccineId { get; set; }
        public virtual Vaccine Vaccine { get; set; }
        public List<PetDetailsVM> Pets { get; set; }
    }
}
