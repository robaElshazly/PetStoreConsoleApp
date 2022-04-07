using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStoreConsoleApp
{
    public class Pet
    {
        public long Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string[] PhotoUrls { get; set; }
        public Tag[] Tags { get; set; }

        public Status Status { get; set; }
    }

    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
    public class Tag
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public enum Status
    {
        Available,
        Pending,
        Sold
    }


    class Program
    {
        static HttpClient client = new HttpClient();
        static async Task Main()
        {
            JsonSerializerOptions options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
            {
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
            };

            var result = await client.GetAsync("https://petstore.swagger.io/v2/pet/findByStatus?status=available");
            var json = await result.Content.ReadAsStringAsync();
            var pets = JsonSerializer.Deserialize<Pet[]>(json, options);

            foreach (var pet in pets)
            {
                Console.WriteLine($"Pet Name: {pet.Name}, Category:{pet.Category?.Name}");
            }
        }
    }
}
