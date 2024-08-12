using Application.Features.Actors;
using Application.Features.Actors.CreateActor;
using Application.Features.Actors.GetActor;
using Application.Features.Actors.UpdateActor;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Features;

public class ActorsService : IActorsService
{
    private ApplicationContext _context;

    public ActorsService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateActorAsync(CreateActorCommand request)
    {
        var actor = new Actor()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth
        };

        if (request.Movies != null)
        {
            var movies = await _context.Movies.Where(x => request.Movies.Contains(x.Id)).ToListAsync();
            actor.Movies = movies;
        }

        await _context.AddAsync(actor);
        await _context.SaveChangesAsync();

        return actor.Id;
    }

    public async Task DeleteActorAsync(Guid id)
    {
        var actor = await _context.Actors.Where(x => x.Id == id).FirstOrDefaultAsync() ?? throw new Exception("Entiteta ne obstaja!");
        _context.Remove(actor);
        await _context.SaveChangesAsync();
    }

    public async Task<GetActorResponse> GetActorByIdAsync(Guid id)
    {
        return (await _context.Actors.Include(x => x.Movies).Where(x => x.Id == id).FirstOrDefaultAsync()).Adapt<GetActorResponse>();
    }

    public async Task<List<GetActorResponse>> SearchActorsAsync()
    {
        var actors = await _context.Actors.ToListAsync();

        return actors.Adapt<List<GetActorResponse>>();
    }

    public async Task UpdateActorAsync(UpdateActorCommand request)
    {
        var actor = await _context.Actors.Where(x => x.Id == request.Id).FirstOrDefaultAsync() ?? throw new Exception("Entiteta ne obstaja!");

        actor.FirstName = request.FirstName;
        actor.LastName = request.LastName;
        actor.DateOfBirth = request.DateOfBirth;

        actor.Movies.Clear();

        if (request.Movies != null)
        {
            var movies = await _context.Movies.Where(x => request.Movies.Contains(x.Id)).ToListAsync();
            actor.Movies = movies;
        }

        _context.Update(actor);
        await _context.SaveChangesAsync();
    }
}
