using Application.Features.Movies.GetMovie;
using Application.Pagination;
using MediatR;

namespace Application.Features.Movies.SearchMovies;

public class SearchMoviesCommand : PaginationFilter, IRequest<PaginationResponse<GetMovieResponse>>
{
}
