﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PetShelter.Data.Entities;
using PetShelter.Shared.Attributes;
using PetShelter.Shared.Dtos;
using PetShelter.Shared.Repos.Contracts;
using PetShelter.Shared.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Data.Repos
{
    [AutoBind]

    public class UserRepository : BaseRepository<User, UserDto>, IUserRepository
    {
        public UserRepository(PetShelterDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<bool> CanUserLoginAsync(string username, string password)
        {
            var hashedPassword = (await this.GetByUsernameAsync(username))?.Password;
            return PasswordHasher.VerifyPassword(password, hashedPassword);
        }

        public async Task<UserDto> GetByUsernameAsync(string username)
        {
            return MapToModel(await _dbSet.FirstOrDefaultAsync(u => u.Username == username));
        }
    }
}


