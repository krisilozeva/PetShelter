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
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock = new Mock<IUserRepository>();
        private readonly IUserService _service;

        public UserServiceTests()
        {
            _service = new UserService(_userRepositoryMock.Object);
        }
        [Test]
        public async Task WhenCreateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var userDto = new UserDto()
            {

                Username = "sharo.sharov123",
                Password = "sharo.sharov123",
                FirstName = "Sharo",
                LastName = "Sharov",
                RoleId = 2,
                ShelterId = 3

            };

            //Act
            await _service.SaveAsync(userDto);

            //Asert
            _userRepositoryMock.Verify(x => x.SaveAsync(userDto), Times.Once());


        }

        [Test]
        public async Task WhenSaveAsync_WithNull_ThenThrowArgumentNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _service.SaveAsync(null));
            _userRepositoryMock.Verify(x => x.SaveAsync(null), Times.Never());
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
            _userRepositoryMock.Verify(x => x.DeleteAsync(It.Is<int>(i => i.Equals(id))), Times.Once);
        }


        [Theory]
        [TestCase(1)]
        [TestCase(22)]
        [TestCase(131)]
        public async Task WhenGetByIdAsync_WithValidBreedId_ThenReturnUser(int userId)
        {
            //Arrange
            var userDto = new UserDto()
            {
                Username = "sharo.sharov123",
                Password = "sharo.sharov123",
                FirstName = "Sharo",
                LastName = "Sharov",
                RoleId = 2,
                ShelterId = 3
            };
            _userRepositoryMock.Setup(s => s.GetByIdIfExistsAsync(It.Is<int>(x => x.Equals(userId))))
                .ReturnsAsync(userDto);
            //Act
            var userResult = await _service.GetByIdIfExistsAsync(userId);

            //Assert
            _userRepositoryMock.Verify(x => x.GetByIdIfExistsAsync(userId), Times.Once);
            Assert.That(userResult == userDto);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(102021)]
        public async Task WhenGetByAsync_WithInvalidBreedId_ThenReturnDefault(int userId)
        {
            var user = (UserDto)default;
            _userRepositoryMock.Setup(s => s.GetByIdIfExistsAsync(It.Is<int>(x => x.Equals(userId))))
                .ReturnsAsync(user);

            //Act
            var userResult = await _service.GetByIdIfExistsAsync(userId);

            //Assert
            _userRepositoryMock.Verify(x => x.GetByIdIfExistsAsync(userId), Times.Once);
            Assert.That(userResult == user);

        }

        [Test]
        public async Task WhenUpdateAsync_WithValidData_ThenSaveAsync()
        {
            //Arrange
            var userDto = new UserDto
            {

                Username = "sharo.sharov123",
                Password = "sharo.sharov123",
                FirstName = "Sharo",
                LastName = "Sharov",
                RoleId = 2,
                ShelterId = 3

            };
            _userRepositoryMock.Setup(s => s.SaveAsync(It.Is<UserDto>(x => x.Equals(userDto))))
               .Verifiable();
            //Act
            await _service.SaveAsync(userDto);

            //Assert
            _userRepositoryMock.Verify(x => x.SaveAsync(userDto), Times.Once);
        }

    }
}


