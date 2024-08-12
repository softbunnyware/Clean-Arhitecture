using MediatR;

namespace Application.Features.Actors.GetActor;

public class GetActorCommand : IRequest<GetActorResponse>
{
    public Guid Id { get; set; }

    public GetActorCommand(Guid id)
    {
        Id = id;
    }
}
