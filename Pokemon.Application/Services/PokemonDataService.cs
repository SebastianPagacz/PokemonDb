using Newtonsoft.Json;
using Pokemon.Domain.Dtos;
using Pokemon.Domain.Repositories;

namespace Pokemon.Application.Services
{
    public class PokemonDataService(HttpClient client, IPokemonRepository repository) : IPokemonDataService
    {
        public async Task GetPokemonsAsync()
        {
            var data = await client.GetStringAsync("https://pokeapi.co/api/v2/pokemon?limit=151");

            var response = JsonConvert.DeserializeObject<PokemonListResponse>(data);

            if (response != null)
            {
                foreach (var item in response.Results)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }
}
