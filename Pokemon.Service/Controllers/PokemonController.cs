using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pokemon.Application.CQRS.PokemonQueries;
using Pokemon.Domain.Models;
using Pokemon.Domain.Repositories;

namespace Pokemon.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonController(IPokemonRepository repository, IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add(PokemonEntity entity)
    {
        await repository.AddAsync(entity);

        return StatusCode(200, entity);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await mediator.Send(new GetPokemonsQuery());

        return StatusCode(200, result);
    }
}
