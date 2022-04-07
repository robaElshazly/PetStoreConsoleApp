using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PetStoreConsoleApp
{
    class Program
    {     
        static async Task Main()
        {
            var petService = new PetService("https://petstore.swagger.io/v2/pet/");
            Pet[] pets;
            try
            {
                pets = await petService.GetAvailablePetsAsync();
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("Pet store API service is down, please retry later");
                return;
            }
            catch (JsonException)
            {
                Console.WriteLine("Result from Pet store API is unexpected, please retry later");
                return;
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong, please retry later");
                return;
            }

            var sortedPets = petService.SortPets(pets);

            Console.WriteLine("Display all pets");
            petService.DisplayPets(sortedPets);

            return;
        }
    }
}
