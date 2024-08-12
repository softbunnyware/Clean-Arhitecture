using Application.Features.Actors.CreateActor;
using Application.Features.Actors.DeleteActor;
using Application.Features.Actors.GetActor;
using Application.Features.Actors.SearchActors;
using Application.Features.Actors.UpdateActor;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers.Base;

namespace Server.Controllers;

public class ActorsController : BaseController
{
    [HttpGet("{id:guid}")]
    public async Task<GetActorResponse> GetAsync(Guid id)
    {
        return await Mediator.Send(new GetActorCommand(id));
    }

    [HttpGet("search")]
    public async Task<List<GetActorResponse>> SearchAsync()
    {
        return await Mediator.Send(new SearchActorsCommand());
    }

    [HttpPost("create")]
    public async Task<Guid> CreateAsync(CreateActorCommand request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("update")]
    public async Task UpdateAsync(UpdateActorCommand request)
    {
        await Mediator.Send(request);
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task DeleteAsync(Guid id)
    {
        await Mediator.Send(new DeleteActorCommand(id));
    }
}
