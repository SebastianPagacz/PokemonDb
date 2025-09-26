using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Application.CQRS.PokemonCommands;
using Pokemon.Application.CQRS.PokemonQueries;
using Pokemon.Domain.Dtos;

namespace Pokemon.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add(PokemonDto entity)
    {
        var result = await mediator.Send(new AddPokemonCommand
        {
            PokemonId = entity.PokemonId,
            Name = entity.Name,
            Type = entity.Type,
        });

        return StatusCode(200, entity);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetPokemonsQuery());

        return StatusCode(200, result);
    }
}
