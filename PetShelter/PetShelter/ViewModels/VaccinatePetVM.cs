using System.Collections;

namespace PetShelter.ViewModels
{
    public class VaccinatePetVM
    {
        public int PetId { get; set; }

        public int VaccineId { get; set; }

        public IEnumerable VaccineList { get; set; }
    }
}