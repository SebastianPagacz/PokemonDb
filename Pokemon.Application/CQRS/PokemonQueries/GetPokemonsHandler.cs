using MediatR;
using Pokemon.Domain.Models;
using Pokemon.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Application.CQRS.PokemonQueries
{
    public class GetPokemonsHandler(IPokemonRepository repository) : IRequestHandler<GetPokemonsQuery, List<PokemonEntity>>
    {
        public async Task<List<PokemonEntity>> Handle(GetPokemonsQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetAsync();
        }
    }
}
