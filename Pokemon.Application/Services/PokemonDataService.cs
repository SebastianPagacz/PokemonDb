using Newtonsoft.Json;
using Pokemon.Domain.Dtos;
using Pokemon.Domain.Models;
using Pokemon.Domain.Repositories;

namespace Pokemon.Application.Services
{
    public class PokemonDataService(HttpClient client, DataContext context, IPokemonRepository repository) : IPokemonDataService
    {
        public async Task GetPokemonsAsync()
        {
            if (!context.Pokemons.Any()) 
            {
                var data = await client.GetStringAsync("https://pokeapi.co/api/v2/pokemon?limit=151");
                var response = JsonConvert.DeserializeObject<PokemonListResponse>(data);

                if (response != null)
                {
                    for (int i = 0; i < response.Results.Count; i++)
                    {
                        var newPokemon = new PokemonEntity
                        {
                            Id = int.Parse(response.Results[i].Url.TrimEnd('/').Split('/').Last()),
                            Name = response.Results[i].Name,
                        };
                        await repository.AddAsync(newPokemon);
                    }
                }
            }
        }
    }
}
