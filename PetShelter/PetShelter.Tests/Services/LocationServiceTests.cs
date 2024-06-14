﻿using Moq;
using PetShelter.Data.Entities;
using PetShelter.Services;
using PetShelter.Shared.Dtos;
using PetShelter.Shared.Enums;
using PetShelter.Shared.Repos.Contracts;
using PetShelter.Shared.Services;
using PetShelter.Shared.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelter.Test.Service
{
    public class LocationServiceTests
    {
        private readonly Mock<ILocationRepository> _locationRepositoryMock = new Mock<ILocationRepository>();
        private readonly ILocationService _service;

        public LocationServiceTests()
        {
            _service = new LocationService(_locationRepositoryMock.Object);
        }
        [Test]
        public async Task WhenCreateAsync_WithValidDate_ThenSaveAsync()
        {
            //Arrange
            var locationDto = new LocationDto
            {
                Id = 1,
                City = "Sofia",
                Address = "Georgi Rakovski 35",
                Country = "Bulgaria",
                ShelterId = 0
            };
            //Act
            await _service.SaveAsync(locationDto);
            //Assert
            _locationRepositoryMock.Verify(x => x.SaveAsync(locationDto), Times.Once());
        }


        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _locationRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never);
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
            _locationRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }
        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnUser(int locationId)
        {
            //Arrange
            var locationDto = new LocationDto
            {
                Id = 1,
                City = "Sofia",
                Address = "Georgi Rakovski 35",
                Country = "Bulgaria",
                ShelterId = 0
            };


            _locationRepositoryMock.Setup(x => x.GetByIdIfExistsAsync(It.Is<int>(x => x.Equals(locationId))))
                .ReturnsAsync(locationDto);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(locationId);
            //Assert
            _locationRepositoryMock.Verify(x => x.GetByIdIfExistsAsync(locationId), Times.Once());
            Assert.That(userResult == locationDto);
        }
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByIdAsync_WithInvalidBreedId_ThenReturnDefault(int locationId)
        {
            //Arrange
            var location = (LocationDto)default;
            _locationRepositoryMock.Setup(s => s.GetByIdIfExistsAsync(It.Is<int>(x => x.Equals(locationId))))
            .ReturnsAsync(location);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(locationId);

            //Assert
            _locationRepositoryMock.Verify(x => x.GetByIdIfExistsAsync(locationId), Times.Once());
            Assert.That(userResult == location);
        }
        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var locationDto = new LocationDto
            {
                Id = 1,
                City = "Sofia",
                Address = "Georgi Rakovski 35",
                Country = "Bulgaria",
                ShelterId = 0
            };
            _locationRepositoryMock.Setup(s => s.SaveAsync(It.Is<LocationDto>(x => x.Equals(locationDto))))
                .Verifiable();
            //Act
            await _service.SaveAsync(locationDto);
            //Assert
            _locationRepositoryMock.Verify(x => x.SaveAsync(locationDto), Times.Once());
        }
    }
}
