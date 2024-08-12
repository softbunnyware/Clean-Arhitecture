using Application.Features.Movies.GetMovie;
using MediatR;

namespace Application.Features.Movies.SearchMovies;

public class SearchMoviesHandler : IRequestHandler<SearchMoviesCommand, List<GetMovieResponse>>
{
    private readonly IMoviesService _service;

    public SearchMoviesHandler(IMoviesService service)
    {
        _service = service;
    }

    public async Task<List<GetMovieResponse>> Handle(SearchMoviesCommand request, CancellationToken cancellationToken)
    {
        return await _service.SearchMoviesAsync();
    }
}
