namespace PetShelter.ViewModels
{
    public class LocationDetailsVM : BaseVM
    {
        public string City { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public int ShelterId { get; set; }
        public List<PetDetailsVM> Pets { get; set; }
    }
}
