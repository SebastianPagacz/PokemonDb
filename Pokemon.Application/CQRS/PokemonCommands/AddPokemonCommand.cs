using MediatR;
using Pokemon.Domain.Enums;
using Pokemon.Domain.Models;

namespace Pokemon.Application.CQRS.PokemonCommands;

public record AddPokemonCommand : IRequest<PokemonEntity>
{
    public int PokemonId { get; set; }
    public string Name { get; set; } = string.Empty;
    public PokemonTypeEnum Type { get; set; }
}
