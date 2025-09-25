using Microsoft.EntityFrameworkCore;
using Pokemon.Domain.Models;

namespace Pokemon.Domain.Repositories;

public class PokemonRepository(DataContext context) : IPokemonRepository
{
    public async Task<PokemonEntity> AddAsync(PokemonEntity entity)
    {
        await context.Pokemons.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<List<PokemonEntity>> GetAsync()
    {
        return await context.Pokemons.ToListAsync();
    }

    public async Task<PokemonEntity> GetByIdASync(int id)
    {
        return await context.Pokemons.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<PokemonEntity> UpdateAsync(PokemonEntity entity)
    {
        await context.SaveChangesAsync();
        
        return entity;
    }
}
