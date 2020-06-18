using Microsoft.VisualStudio.TestTools.UnitTesting;
using APIIntegrationTestsExample.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace APIIntegrationTestsExample.Controllers.Tests
{
    [TestClass()]
    public class PokedexControllerTests
    {
        private PokemonViewModel sutObjectResult;

        [TestMethod()]
        public async Task GetTest()
        {
            // intstall Microsoft.AspNetCore.Mvc.Testing
            var factory = new WebApplicationFactory<APIIntegrationTestsExample.Program>();

            var client = factory.WithWebHostBuilder(builder =>
            {

                // Microsoft.AspNetCore.TestHost;
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<IPokemonService, MockPokemonService>();
                });
            }).CreateClient();

            HttpResponseMessage sutHttpResponse = await client.GetAsync($"/api/pokedex/dragonite");
            string stringContent = await sutHttpResponse.Content.ReadAsStringAsync();
            // Act
            sutObjectResult = JsonSerializer.Deserialize<PokemonViewModel>(stringContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });


            Assert.AreEqual(12, sutObjectResult.Number);
        }


    }


    public class MockPokemonService : IPokemonService
    {
        public async Task<PokemonInfo> GetPokemonInfo(string pokemonName)
        {
            return new PokemonInfo { Name = pokemonName, Order = 12, Id = 12, Types = new List<TypeElement>() { new TypeElement() { Type = new Species() { Name = "My Name" } } } };
        }
    }
}