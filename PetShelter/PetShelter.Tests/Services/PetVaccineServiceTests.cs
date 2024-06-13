using Moq;
using PetShelter.Data.Entities;
using PetShelter.Services;
using PetShelter.Shared.Dtos;
using PetShelter.Shared.Repos.Contracts;
using PetShelter.Shared.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Test.Service
{
    public class PetVaccineServiceTests
    {
        private readonly Mock<IPetVaccineRepository> _petVaccineRepositoryMock = new Mock<IPetVaccineRepository>();
        private readonly IPetVaccineService _service;

        public PetVaccineServiceTests()
        {
            _service = new PetVaccineService(_petVaccineRepositoryMock.Object);
        }
        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var petvaccineDto = new PetVaccineDto()
            {
                VaccineId = 0,
                PetId = 4

            };

            //Act
            await _service.SaveAsync(petvaccineDto);

            //Asert
            _petVaccineRepositoryMock.Verify(x => x.SaveAsync(petvaccineDto), Times.Once());


        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _petVaccineRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never());
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
            _petVaccineRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }


        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnUser(int petVaccineId)
        {
            //Arrange
            var petvaccineDto = new PetVaccineDto()
            {
                VaccineId = 0,
                PetId = 4
            };
            _petVaccineRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(petVaccineId))))
                .ReturnsAsync(petvaccineDto);
            //Act
            var userResult = await _service.GetByIdIfExistsAsync(petVaccineId);

            //Assert
            _petVaccineRepositoryMock.Verify(x => x.GetByIdAsync(petVaccineId), Times.Once);
            Assert.That(userResult == petvaccineDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByAsync_WithInvalidBreedId_ThenReturnDefault(int petVaccineId)
        {
            var petVaccine = (PetVaccineDto)default;
            _petVaccineRepositoryMock.Setup(s => s.GetByIdAsync(It.Is<int>(x => x.Equals(petVaccineId))))
                .ReturnsAsync(petVaccine);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(petVaccineId);

            //Assert
            _petVaccineRepositoryMock.Verify(x => x.GetByIdAsync(petVaccineId), Times.Once);
            Assert.That(userResult == petVaccine);

        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var petVaccineDto = new PetVaccineDto
            {
                VaccineId = 0,
                PetId = 4

            };
            _petVaccineRepositoryMock.Setup(s => s.SaveAsync(It.Is<PetVaccineDto>(x => x.Equals(petVaccineDto))))
               .Verifiable();
            //Act
            await _service.SaveAsync(petVaccineDto);

            //Assert
            _petVaccineRepositoryMock.Verify(x => x.SaveAsync(petVaccineDto), Times.Once);
        }

    }
}

