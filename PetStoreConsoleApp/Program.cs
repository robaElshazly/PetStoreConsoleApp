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

            Console.WriteLine($" ----------------------------------------- ");
            Console.WriteLine($"|{"Category",-20}|{"Pet Name",-20}|");
            Console.WriteLine($" ----------------------------------------- ");
            foreach (var pet in sortedPets)
            {
                Console.WriteLine(pet);
            }

            return;
        }
    }
}
