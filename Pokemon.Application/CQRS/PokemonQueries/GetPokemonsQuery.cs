using MediatR;
using Pokemon.Domain.Models;

namespace Pokemon.Application.CQRS.PokemonQueries;

public record GetPokemonsQuery : IRequest<List<PokemonEntity>> {}
