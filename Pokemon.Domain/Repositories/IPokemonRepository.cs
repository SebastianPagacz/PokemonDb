using Pokemon.Domain.Models;

namespace Pokemon.Domain.Repositories;

public interface IPokemonRepository
{
    Task<PokemonEntity> AddAsync(PokemonEntity entity);
    Task<PokemonEntity> GetByIdASync(int id);
    Task<List<PokemonEntity>> GetAsync();
    Task<PokemonEntity> UpdateAsync(PokemonEntity entity);
}
