using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using PetShelter.Data.Entities;
using PetShelter.Data.Repos;
using PetShelter.Data;
using PetShelter.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShelter.Services;

namespace PetShelter.Tests.Services
{
    public abstract class BaseCrudServiceTests<TService, T, TModel, TRepository>
        where TService : BaseCrudService<TModel, TRepository>
        where T : class, IBaseEntity
        where TModel : BaseModel
        where TRepository : BaseRepository<T, TModel>
       
    {
        private Mock<PetShelterDbContext> mockContext;
        private Mock<DbSet<T>> mockDbSet;
        private Mock<IMapper> mockMapper;
        private TService service;
        [SetUp]
        public void Setup()
        {
            mockContext = new Mock<PetShelterDbContext>();
            mockDbSet = new Mock<DbSet<T>>();
            mockMapper = new Mock<IMapper>();
            service = new Mock<TService>(mockContext.Object, mockMapper.Object)
            { CallBase = true }.Object;
        }
    {
    }
}
