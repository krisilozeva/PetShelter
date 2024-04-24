﻿using System.ComponentModel.DataAnnotations;

namespace PetShelter.ViewModels
{
    public class LocationEditVM : BaseVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
