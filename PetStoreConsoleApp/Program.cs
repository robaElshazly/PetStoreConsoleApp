using System;
using System.Threading.Tasks;

namespace PetStoreConsoleApp
{
    class Program
    {     
        static async Task Main()
        {
            var petService = new PetService();
            var pets = await petService.GetAvailablePetsAsync();
            var sortedPets = petService.SortPets(pets);

            Console.WriteLine("Display all pets");
            petService.DisplayPets(sortedPets);

            return;
        }
    }
}
