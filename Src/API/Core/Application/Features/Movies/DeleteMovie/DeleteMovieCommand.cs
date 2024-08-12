using MediatR;

namespace Application.Features.Movies.DeleteMovie;

public class DeleteMovieCommand : IRequest
{
    public Guid Id { get; set; }

    public DeleteMovieCommand(Guid id)
    {
        Id = id;
    }
}
