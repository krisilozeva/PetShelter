using PetShelter.Data.Entities;

namespace PetShelter.ViewModels
{
    public class UserDetailsVM : BaseVM
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }

        public int? ShelterId { get; set; }

        public virtual Shelter Shelter { get; set; }

        public virtual List<Pet> AdoptedPets { get; set; }

        public virtual List<Pet> GivenPets { get; set; }
        public virtual List<Pet> Pets { get; set; }
    }
}