using MediatR;

namespace Application.Features.Actors.CreateActor;

public class CreateActorHandler : IRequestHandler<CreateActorCommand, Guid>
{
    private readonly IActorsService _service;

    public CreateActorHandler(IActorsService service)
    {
        _service = service;
    }

    public async Task<Guid> Handle(CreateActorCommand request, CancellationToken cancellationToken)
    {
        return await _service.CreateActorAsync(request);
    }
}
