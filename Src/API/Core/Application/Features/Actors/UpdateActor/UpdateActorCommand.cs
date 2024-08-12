using MediatR;

namespace Application.Features.Actors.UpdateActor;

public class UpdateActorCommand : IRequest
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<Guid>? Movies { get; set; } = default!;
}
