using System.ComponentModel.DataAnnotations;

namespace PetShelter.ViewModels
{
    public class PetEditVM : BaseVM
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public bool IsAdopted { get; set; }

        [Required]
        public bool IsEuthanized { get; set; }

        [Required]
        public int PetTypeId { get; set; }

        [Required]
        public int BreedId { get; set; }

        [Required]
        public int? AdopterId { get; set; }

        [Required]
        public int? GiverId { get; set; }

        [Required]
        public int? ShelterId { get; set; }
    }
}