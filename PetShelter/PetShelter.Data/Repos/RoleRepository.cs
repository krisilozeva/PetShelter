﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetShelter.Data.Entities;
using PetShelter.Shared.Attributes;
using PetShelter.Shared.Dtos;
using PetShelter.Shared.Repos.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Data.Repos
{
    [AutoBind]
    public class RoleRepository : BaseRepository<Role, RoleDto>, IRoleRepository
    {
        public RoleRepository(PetShelterDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<RoleDto?> GetByNameIfExistsAsync(string name)
        {
            return MapToModel(await _dbSet.FirstOrDefaultAsync(u => u.Name == name));

        }
    }
}