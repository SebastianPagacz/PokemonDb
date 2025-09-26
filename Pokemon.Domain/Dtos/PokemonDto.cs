using Pokemon.Domain.Enums;

namespace Pokemon.Domain.Dtos;

public class PokemonDto
{
    public int PokemonId { get; set; }
    public string Name { get; set; } = string.Empty;
    public PokemonTypeEnum Type { get; set; }
}