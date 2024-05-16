using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PetShelter.ViewModels
{
    public class UserEditVM : BaseVM
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int? RoleId { get; set; }

        [Required]
        public int? ShelterId { get; set; }

        public IEnumerable<SelectListItem> RoleList { get; set; }
        public IEnumerable<SelectListItem> ShelterList { get; set; }




    }
}