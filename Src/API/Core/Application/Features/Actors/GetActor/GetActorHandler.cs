using MediatR;

namespace Application.Features.Actors.GetActor;

public class GetActorHandler : IRequestHandler<GetActorCommand, GetActorResponse>
{
    private readonly IActorsService _service;

    public GetActorHandler(IActorsService service)
    {
        _service = service;
    }

    public async Task<GetActorResponse> Handle(GetActorCommand request, CancellationToken cancellationToken)
    {
        var actor = await _service.GetActorByIdAsync(request.Id);
        return actor;
    }
}
