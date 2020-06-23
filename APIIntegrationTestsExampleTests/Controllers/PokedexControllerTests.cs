using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIIntegrationTestsExample.Controllers.Tests
{
    [TestClass()]
    public class PokedexControllerTests
    {

        [TestMethod]
        public async Task Get_WithRealDependencies()
        {
            var factory = new WebApplicationFactory<APIIntegrationTestsExample.Program>();

            var client = factory.CreateClient();

            HttpResponseMessage sutHttpResponse = await client.GetAsync($"/api/pokedex/magmar");
            string stringContent = await sutHttpResponse.Content.ReadAsStringAsync();
            var sutObjectResult = JsonSerializer.Deserialize<PokemonViewModel>(stringContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.AreEqual("Magmar", sutObjectResult.Name, true);

            Assert.IsTrue(sutHttpResponse.IsSuccessStatusCode);
        }

        [TestMethod()]
        public async Task Get_WithMockedDependency()
        {
            // intstall Microsoft.AspNetCore.Mvc.Testing

            var factory = new WebApplicationFactory<APIIntegrationTestsExample.Program>();

            var client = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<IPokemonService, MockPokemonService>();
                });
            }).CreateClient();

            HttpResponseMessage sutHttpResponse = await client.GetAsync($"/api/pokedex/dragonite");
            string stringContent = await sutHttpResponse.Content.ReadAsStringAsync();

            // Act
            var sutObjectResult = JsonSerializer.Deserialize<PokemonViewModel>(stringContent, new JsonSerializerOptions
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
            return await Task.FromResult(new PokemonInfo
            {
                Name = pokemonName,
                Order = 12,
                Types = new List<TypeElement>() {
                    new TypeElement() { Type = new Species() { Name = "My Name" } } }
            });
        }
    }
}