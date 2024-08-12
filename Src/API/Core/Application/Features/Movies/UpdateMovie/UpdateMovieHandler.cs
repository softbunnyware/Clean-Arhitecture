using Application.Features.Movies.DeleteMovie;
using MediatR;

namespace Application.Features.Movies.UpdateMovie;

public class UpdateMovieHandler : IRequestHandler<UpdateMovieCommand>
{
    private readonly IMoviesService _service;

    public UpdateMovieHandler(IMoviesService service)
    {
        _service = service;
    }

    public async Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        await _service.UpdateMovieAsync(request);
    }
}
