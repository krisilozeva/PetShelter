namespace PetShelter.ViewModels
{
    public class PetVaccineEditVM : BaseVM
    {
        [Required]
        public int PetId { get; set; }
        [Required]
        public int VaccineId { get; set; }
    }
}
