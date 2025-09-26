using Pokemon.Domain.Dtos;

namespace Pokemon.Application.Services;

public interface IPokemonDataService
{
    Task GetPokemonsAsync();
}
