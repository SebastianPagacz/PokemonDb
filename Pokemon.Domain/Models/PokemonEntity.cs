using Pokemon.Domain.Enums;

namespace Pokemon.Domain.Models;

public class PokemonEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
