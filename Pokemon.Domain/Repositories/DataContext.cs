using Microsoft.EntityFrameworkCore;
using Pokemon.Domain.Models;

namespace Pokemon.Domain.Repositories;

public class DataContext : DbContext
{
    public DbSet<PokemonEntity> Pokemons { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
}
