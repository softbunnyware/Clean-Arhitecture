using MediatR;

namespace Application.Features.Movies.GetMovie;

public class GetMovieHandler : IRequestHandler<GetMovieCommand, GetMovieResponse>
{
    private readonly IMoviesService _service;

    public GetMovieHandler(IMoviesService service)
    {
        _service = service;
    }

    public async Task<GetMovieResponse> Handle(GetMovieCommand request, CancellationToken cancellationToken)
    {
        return await _service.GetMovieByIdAsync(request.Id);
    }
}