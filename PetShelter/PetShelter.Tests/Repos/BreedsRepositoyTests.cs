using PetShelter.Data.Entities;
using PetShelter.Data.Repos;
using PetShelter.Shared.Dtos;

namespace PetShelter.Tests.Repos
{
    public class BreedsRepositoryTests:BaseRepositoryTests<BreedsRepository,Breed,BreedDto>
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}