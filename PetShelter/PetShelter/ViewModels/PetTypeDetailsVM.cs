namespace PetShelter.ViewModels
{
    public class PetTypeDetailsVM : BaseVM
    {
        public string Name { get; set; }
        public List<PetDetailsVM> Pets { get; set; }
    }
}
