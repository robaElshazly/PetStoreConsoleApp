using PetStoreConsoleApp;
using System;
using Xunit;

namespace PetStoreUnitTest
{
    public class PetStoreSortTests
    {
        PetService petService = new PetService("https://petstore.swagger.io/v2/pet/findByStatus?status=available");
        [Fact]
        public void GivenUnsortedPets_WhenSort_PetsAreSortedByNameReversed()
        {
            //Arrange
            var petA = new Pet { Name = "A", Category = new Category { Id = 1 } };
            var petB = new Pet { Name = "B", Category = new Category { Id = 1 } };
            var petC = new Pet { Name = "C", Category = new Category { Id = 1 } };

            var pets = new Pet[]
            {
                petB,petC,petA
            };
            //Act
            var sortedPets = petService.SortPets(pets);

            //Assert
            var expected = new Pet[]
            {
               petC,petB,petA
            };

            Assert.Equal(expected, sortedPets);
        }

        [Fact]
        public void GivenUnsortedPets_WhenSort_PetsAreSortedByCategory()
        {
            //Arrange
            var petACat1 = new Pet { Name = "A", Category = new Category { Id = 1, Name = "Cat1" } };
            var petBCat1 = new Pet { Name = "B", Category = new Category { Id = 1, Name = "Cat1" } };
            var petCCat2 = new Pet { Name = "C", Category = new Category { Id = 2, Name = "Cat2" } };

            var pets = new Pet[]
            {
                petBCat1,petCCat2,petACat1
            };
            //Act
            var sortedPets = petService.SortPets(pets);

            //Assert
            var expected = new Pet[]
            {
               petBCat1,petACat1,petCCat2
            };

            Assert.Equal(expected, sortedPets);
        }
    }
}
