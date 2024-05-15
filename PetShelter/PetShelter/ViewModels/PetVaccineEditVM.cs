using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PetShelter.ViewModels
{
    public class PetVaccineEditVM : BaseVM
    {
        [Required]
        public int PetId { get; set; }
        [Required]
        public int VaccineId { get; set; }

        public IEnumerable<SelectListItem> PetList { get; set; }
        public IEnumerable<SelectListItem> VaccineList { get; set; }


    }
}
