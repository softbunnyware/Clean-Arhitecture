using Application.Features.Actors.GetActor;
using Application.Features.Movies.GetMovie;
using MediatR;

namespace Application.Features.Actors.CreateActor;

public class CreateActorCommand : IRequest<Guid>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<Guid> Movies { get; set; } = default!;
}
