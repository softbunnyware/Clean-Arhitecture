using Application.Features.Actors.GetActor;
using MediatR;

namespace Application.Features.Movies.CreateMovie;

public class CreateMovieCommand : IRequest<Guid>
{
    public string? ImdbId { get; set; }
    public required string Title { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public List<Guid>? Actors { get; set; } = default!;
}
