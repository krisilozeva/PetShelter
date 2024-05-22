using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using PetShelter.Data;
using PetShelter.Data.Entities;
using PetShelter.Data.Repos;
using PetShelter.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Tests.Repos
{
    public abstract class BaseRepositoryTests<TRepository, T, TModel>
        where TRepository : BaseRepository<T, TModel>
        where T : class, IBaseEntity
        where TModel : BaseModel
    {
        private Mock<PetShelterDbContext> mockContext;
        private Mock<DbSet<T>> mockDbSet;
        private Mock<IMapper> mockMapper;
        private TRepository repository;
        [SetUp]
        public void Setup()
        {
            mockContext = new Mock<PetShelterDbContext>();
            mockDbSet = new Mock<DbSet<T>>();
            mockMapper = new Mock<IMapper>();
            repository = new Mock<TRepository>(mockContext.Object, mockMapper.Object)
            { CallBase = true }.Object;
        }
        [Test]
        public void MapToModel_ValidEntity_ReturnsMappedModel()
        {
            //Arange
            var entity = new Mock<T>();
            var model = new Mock<TModel>();
            mockMapper.Setup(m => m.Map<TModel>(entity.Object)).Returns(model.Object);

            //Act
            var result = repository.MapToModel(entity.Object);

            //Assert
            Assert.That(result, Is.EqualTo(model.Object));
        }
        [Test]
        public void MapToEntity_ValidModel_ReturnsMappedEntity()
        {
            // Arrange
            var entity = new Mock<T>();
            var model = new Mock<TModel>();
            mockMapper.Setup(m => m.Map<T>(model.Object)).Returns(entity.Object);

            // Act
            var result = repository.MapToEntity(model.Object);

            // Assert
            Assert.That(result, Is.EqualTo(entity.Object));
        }
        [Test]
        public void MapToEnumerableOfModel_WhenCalled_ReturnsMappedEnumerable()
        {
            // Arrange
            var entity = new Mock<List<T>>();
            var model = new Mock<List<TModel>>();
            mockMapper.Setup(m => m.Map<IEnumerable<TModel>>(entity.Object)).Returns(model.Object);


            // Act
            var result = repository.MapToEnumerableOfModel(entity.Object);

            // Assert
            Assert.That(result, Is.EqualTo(model.Object));
            
        }
        [Test]
        public async Task GetAllAsync_ReturnsMappedModels()
        {
            // Arrange
            var entity = new Mock<List<T>>();
            var model = new Mock<List<TModel>>();

            mockDbSet.Setup(async s => await s.ToListAsync()).Returns(Task<entity.Object>);

            mockMapper.Setup(m => m.Map<IEnumerable<TModel>>(entity.Object))
                .Returns(model.Object);
            
            // Act
            var result = await repository.GetAllAsync();

            // Assert
            Assert.That(result, Is.EqualTo(model.Object));
        }
    }



}
