using Application.Features.Actors.GetActor;
using MediatR;

namespace Application.Features.Movies.UpdateMovie;

public class UpdateMovieCommand : IRequest
{
    public Guid Id { get; set; }
    public string? ImdbId { get; set; }
    public required string Title { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public List<Guid>? Actors { get; set; } = default!;
}
