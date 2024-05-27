﻿using PetShelter.Data.Entities;
using PetShelter.Data.Repos;
using PetShelter.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Tests.Repos
{
    public class UserRepositoryTests : BaseRepositoryTests<UserRepository, User, UserDto>
    {
    }
}
