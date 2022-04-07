﻿using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PetStoreConsoleApp
{
    public class PetService
    {
        HttpClient client = new HttpClient { BaseAddress = new Uri("https://petstore.swagger.io/v2/pet/") };
        JsonSerializerOptions options = new JsonSerializerOptions(JsonSerializerDefaults.Web)
        {
            Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
        };

        public async Task<Pet[]> GetAvailablePetsAsync()
        {
            var result = await client.GetAsync("findByStatus?status=available");
            var json = await result.Content.ReadAsStringAsync();
            var pets = JsonSerializer.Deserialize<Pet[]>(json, options);
            return pets;
        }

        public Pet[] SortPets(Pet[] pets)
        {
            return pets.Where(pet => pet.Category != null)
                .OrderBy(pet => pet.Category.Name)
                .ThenByDescending(pet => pet.Name)
                .ToArray();
        }
    }
}
