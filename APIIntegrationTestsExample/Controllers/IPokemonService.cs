using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIIntegrationTestsExample.Controllers
{

    public interface IPokemonService
    {
        Task<PokemonInfo> GetPokemonInfo(string pokemonName);
    }

    public class PokemonService : IPokemonService
    {
        public async Task<PokemonInfo> GetPokemonInfo(string pokemonName)
        {
            PokemonInfo pokeInfo = null;

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{pokemonName}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    JsonSerializerOptions option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    pokeInfo = JsonSerializer.Deserialize<PokemonInfo>(content, option);
                }
                else
                    return null;
            }

            return pokeInfo;
        }
    }
}