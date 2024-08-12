using Application.Features.Movies.CreateMovie;
using Application.Features.Movies.GetMovie;
using Application.Features.Movies.UpdateMovie;
using Application.Services;

namespace Application.Features.Movies;

public interface IMoviesService : IScopedService
{
    Task<GetMovieResponse> GetMovieByIdAsync(Guid id);
    Task<List<GetMovieResponse>> SearchMoviesAsync();
    Task<Guid> CreateMovieAsync(CreateMovieCommand request);
    Task UpdateMovieAsync(UpdateMovieCommand request);
    Task DeleteMovieAsync(Guid id);
}