using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace APIIntegrationTestsExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokedexController : ControllerBase
    {
        private readonly IPokemonService pokemonService;

        public PokedexController(IPokemonService pokemonService)
        {
            this.pokemonService = pokemonService;
        }

        [HttpGet]
        [Route("{pokemonName}")]
        public async Task<ActionResult<PokemonViewModel>> Get(string pokemonName)
        {
            var fullInfo = await pokemonService.GetPokemonInfo(pokemonName);
            if (fullInfo != null)
            {
                return new PokemonViewModel
                {
                    Name = fullInfo.Name,
                    Number = fullInfo.Order,
                    Types = fullInfo.Types.Select(x => x.Type.Name).ToArray()
                };
            }
            else
                return NotFound();
        }
    }

}