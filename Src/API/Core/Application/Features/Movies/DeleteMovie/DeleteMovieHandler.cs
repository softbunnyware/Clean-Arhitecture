using MediatR;

namespace Application.Features.Movies.DeleteMovie;

public class DeleteMovieHandler : IRequestHandler<DeleteMovieCommand>
{
    private readonly IMoviesService _service;

    public DeleteMovieHandler(IMoviesService service)
    {
        _service = service;
    }

    public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        await _service.DeleteMovieAsync(request.Id);
    }
}
