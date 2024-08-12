using MediatR;

namespace Application.Features.Actors.DeleteActor;

public class DeleteActorHandler : IRequestHandler<DeleteActorCommand>
{
    private readonly IActorsService _service;

    public DeleteActorHandler(IActorsService service)
    {
        _service = service;
    }

    public async Task Handle(DeleteActorCommand request, CancellationToken cancellationToken)
    {
        await _service.DeleteActorAsync(request.Id);
    }
}