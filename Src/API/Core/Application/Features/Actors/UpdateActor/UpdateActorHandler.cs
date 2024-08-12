using MediatR;

namespace Application.Features.Actors.UpdateActor;

public class UpdateActorHandler : IRequestHandler<UpdateActorCommand>
{
    private readonly IActorsService _service;

    public UpdateActorHandler(IActorsService service)
    {
        _service = service;
    }

    public async Task Handle(UpdateActorCommand request, CancellationToken cancellationToken)
    {
        await _service.UpdateActorAsync(request);
    }
}