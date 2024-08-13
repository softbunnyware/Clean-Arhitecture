using Application.Features.Movies.CreateMovie;
using Application.Features.Movies.GetMovie;
using Application.Features.Movies.UpdateMovie;
using Application.Features.Movies;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Pagination;
using Application.Pagination;
using Application.Features.Movies.SearchMovies;

namespace Infrastructure.Features;

public class MoviesService : IMoviesService
{
    private ApplicationContext _context;

    public MoviesService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateMovieAsync(CreateMovieCommand request)
    {
        var movie = new Movie()
        {
            ImdbId = request.ImdbId,
            Title = request.Title,
            Description = request.Description,
            Date = request.Date
        };

        if(request.Actors != null)
        {
            var actors = await _context.Actors.Where(x => request.Actors.Contains(x.Id)).ToListAsync();
            movie.Actors = actors;
        }

        await _context.AddAsync(movie);
        await _context.SaveChangesAsync();

        return movie.Id;
    }

    public async Task DeleteMovieAsync(Guid id)
    {
        var movie = await _context.Movies.Where(x => x.Id == id).FirstOrDefaultAsync() ?? throw new Exception("Entiteta ne obstaja!");
        _context.Remove(movie);
        await _context.SaveChangesAsync();
    }

    public async Task<GetMovieResponse> GetMovieByIdAsync(Guid id)
    {
        return (await _context.Movies.Where(x => x.Id == id).FirstOrDefaultAsync()).Adapt<GetMovieResponse>();
    }

    public async Task<PaginationResponse<GetMovieResponse>> SearchMoviesAsync(SearchMoviesCommand request)
    {
        return await _context.Movies.Include(x => x.Actors).ToPagedListAsync<Movie, GetMovieResponse>(request.PageNumber,request.PageSize);
    }

    public async Task UpdateMovieAsync(UpdateMovieCommand request)
    {
        var movie = await _context.Movies.Where(x => x.Id == request.Id).FirstOrDefaultAsync() ?? throw new Exception("Entiteta ne obstaja!");

        movie.ImdbId = request.ImdbId;
        movie.Title = request.Title;
        movie.Description = request.Description;
        movie.Date = request.Date;

        movie.Actors.Clear();

        if (request.Actors != null)
        {
            var actors = await _context.Actors.Where(x => request.Actors.Contains(x.Id)).ToListAsync();
            movie.Actors = actors;
        }

        _context.Update(movie);
        await _context.SaveChangesAsync();
    }
}
