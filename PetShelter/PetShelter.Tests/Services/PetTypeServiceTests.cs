using Moq;
using PetShelter.Data.Entities;
using PetShelter.Services;
using PetShelter.Shared.Dtos;
using PetShelter.Shared.Repos.Contracts;
using PetShelter.Shared.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Test.Service
{
    public class PetTypeServiceTests
    {
        private readonly Mock<IPetTypeRepository> _petTypeRepositoryMock = new Mock<IPetTypeRepository>();
        private readonly IPetTypeService _service;

        public PetTypeServiceTests()
        {
            _service = new PetTypeService(_petTypeRepositoryMock.Object);
        }
        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var petTypeDto = new PetTypeDto()
            {
                Name = "Izabel"
            };

            //Act
            await _service.SaveAsync(petTypeDto);

            //Asert
            _petTypeRepositoryMock.Verify(x => x.SaveAsync(petTypeDto), Times.Once());


        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _petTypeRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never());
        }

        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenDeleteAsync_WithCorrectId_ThenCallDeleteAsyncInRepository(int id)
        {
            //Arrange

            //Act
            await _service.DeleteAsync(id);

            //Assert
            _petTypeRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }


        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithInvalidBreedId_ThenReturnDefault(int petTypeId)
        {
            //Arrange
            var petTypeDto = new PetTypeDto()
            {
                Name = "Izabel",
            };
            _petTypeRepositoryMock.Setup(s => s.GetByIdIfExistsAsync(It.Is<int>(x => x.Equals(petTypeId))))
                .ReturnsAsync(petTypeDto);
            //Act
            var userResult = await _service.GetByIdIfExistsAsync(petTypeId);

            //Assert
            _petTypeRepositoryMock.Verify(x => x.GetByIdIfExistsAsync(petTypeId), Times.Once);
            Assert.That(userResult == petTypeDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByAsync_WithInvalidBreedId_ThenReturnDefault(int petTypeId)
        {
            var petType = (PetTypeDto)default;
            _petTypeRepositoryMock.Setup(s => s.GetByIdIfExistsAsync(It.Is<int>(x => x.Equals(petTypeId))))
                .ReturnsAsync(petType);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(petTypeId);

            //Assert
            _petTypeRepositoryMock.Verify(x => x.GetByIdIfExistsAsync(petTypeId), Times.Once);
            Assert.That(userResult == petType);

        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var petTypeDto = new PetTypeDto
            {
                Name = "Izabel",

            };
            _petTypeRepositoryMock.Setup(s => s.SaveAsync(It.Is<PetTypeDto>(x => x.Equals(petTypeDto))))
               .Verifiable();
            //Act
            await _service.SaveAsync(petTypeDto);

            //Assert
            _petTypeRepositoryMock.Verify(x => x.SaveAsync(petTypeDto), Times.Once);
        }

    }
}


