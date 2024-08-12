using MediatR;

namespace Application.Features.Movies.GetMovie;

public class GetMovieCommand : IRequest<GetMovieResponse>
{
    public Guid Id { get; set; }

    public GetMovieCommand(Guid id)
    {
        Id = id;
    }
}
