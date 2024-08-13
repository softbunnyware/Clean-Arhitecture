using Application.Features.Movies.GetMovie;
using Application.Pagination;
using MediatR;

namespace Application.Features.Movies.SearchMovies;

public class SearchMoviesHandler : IRequestHandler<SearchMoviesCommand, PaginationResponse<GetMovieResponse>>
{
    private readonly IMoviesService _service;

    public SearchMoviesHandler(IMoviesService service)
    {
        _service = service;
    }

    public async Task<PaginationResponse<GetMovieResponse>> Handle(SearchMoviesCommand request, CancellationToken cancellationToken)
    {
        return await _service.SearchMoviesAsync(request);
    }
}
