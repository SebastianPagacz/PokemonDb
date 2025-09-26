namespace Pokemon.Domain.Dtos;

public class PokemonListResponse
{
    public int Count { get; set; }
    public string? Next { get; set; }
    public string? Previous { get; set; }
    public List<PokemonRequestDto> Results { get; set; }
}
