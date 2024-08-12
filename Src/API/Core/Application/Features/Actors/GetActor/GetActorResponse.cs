using Application.Features.Movies.GetMovie;

namespace Application.Features.Actors.GetActor;

public class GetActorResponse
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public virtual ICollection<BaseMovieResponse> Movies { get; set; } = default!;
}

public class BaseActorResponse
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
}
