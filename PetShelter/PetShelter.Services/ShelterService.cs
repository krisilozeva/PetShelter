﻿using PetShelter.Services.Services.Contracts;
using PetShelter.Shared.Attributes;
using PetShelter.Shared.Dtos;
using PetShelter.Shared.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Services
{
    [AutoBind]
    public class ShelterService : BaseCrudService<ShelterDto, IShelterRepository>, IShelterService
    {
        public ShelterService(IShelterRepository repository) : base(repository) { }
    }
}
