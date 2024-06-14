using AutoMapper;
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
    public class PetVaccineRepository : BaseRepository<PetVaccine, PetVaccineDto>, IPetVaccineRepository
    {
        public PetVaccineRepository(PetShelterDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task VaccinatePetAsync(int petId, int vaccineId)
        {
            PetVaccineDto petVaccineDto = new PetVaccineDto();
            petVaccineDto.VaccineId = petId;
            petVaccineDto.PetId = vaccineId;
            await SaveAsync(petVaccineDto);
        }
    }
}