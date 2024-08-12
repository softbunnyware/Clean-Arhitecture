using Application.Features.Actors.GetActor;

namespace Application.Features.Movies.GetMovie;

public class GetMovieResponse
{
    public Guid Id { get; set; }
    public string? ImdbId { get; set; }
    public required string Title { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public List<BaseActorResponse>? Actors { get; set; } = default!;
}

public class BaseMovieResponse
{
    public Guid Id { get; set; }
    public string? ImdbId { get; set; }
    public required string Title { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
}
