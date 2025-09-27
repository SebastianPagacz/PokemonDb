using MediatR;
using Pokemon.Domain.Models;
using Pokemon.Domain.Repositories;

namespace Pokemon.Application.CQRS.PokemonCommands;

public class AddPokemonHandler(IPokemonRepository repository) : IRequestHandler<AddPokemonCommand, PokemonEntity>
{
    public async Task<PokemonEntity> Handle(AddPokemonCommand request, CancellationToken cancellationToken)
    {
        var newPokemon = new PokemonEntity
        {
            Id = request.PokemonId,
            Name = request.Name,
        };

        await repository.AddAsync(newPokemon);

        return newPokemon;
    }
}
