using MediatR;

namespace Application.Features.Movies.CreateMovie;

public class CreateMovieHandler : IRequestHandler<CreateMovieCommand, Guid>
{
    private readonly IMoviesService _service;

    public CreateMovieHandler(IMoviesService service)
    {
        _service = service;
    }

    public async Task<Guid> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        return await _service.CreateMovieAsync(request);
    }
}
