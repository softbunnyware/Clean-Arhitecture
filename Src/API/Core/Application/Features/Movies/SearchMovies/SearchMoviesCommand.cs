using Application.Features.Movies.GetMovie;
using MediatR;

namespace Application.Features.Movies.SearchMovies;

public class SearchMoviesCommand : IRequest<List<GetMovieResponse>>
{
}
