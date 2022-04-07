using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStoreConsoleApp
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static JsonSerializerOptions options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
        };
        static public async Task<Pet[]> GetAvailablePetsAsync()
        {
            var result = await client.GetAsync("https://petstore.swagger.io/v2/pet/findByStatus?status=available");
            var json = await result.Content.ReadAsStringAsync();
            var pets = JsonSerializer.Deserialize<Pet[]>(json, options);
            return pets;
        }

        static public Pet[] SortPets(Pet[] pets)
        {
            return pets.Where(pet => pet.Category != null)
                .OrderBy(pet => pet.Category.Name)
                .ThenByDescending(pet => pet.Name).ToArray();
        }
        static async Task Main()
        {
            var pets = await GetAvailablePetsAsync();
            var sortedPets = SortPets(pets);

            foreach (var pet in sortedPets)
            {
                Console.WriteLine($"Category:{pet.Category?.Name}, Pet Name: {pet.Name}");
            }

            return;
        }
    }
}
