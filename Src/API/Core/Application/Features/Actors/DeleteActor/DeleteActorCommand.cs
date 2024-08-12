using MediatR;

namespace Application.Features.Actors.DeleteActor;

public class DeleteActorCommand : IRequest
{
    public Guid Id { get; set; }

    public DeleteActorCommand(Guid id)
    {
        Id = id;
    }
}
