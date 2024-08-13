using Application.Features.Actors.CreateActor;
using Application.Features.Actors.GetActor;
using Application.Features.Actors.SearchActors;
using Application.Features.Actors.UpdateActor;
using Application.Pagination;
using Application.Services;

namespace Application.Features.Actors;

public interface IActorsService : IScopedService
{
    Task<GetActorResponse> GetActorByIdAsync(Guid id);
    Task<PaginationResponse<GetActorResponse>> SearchActorsAsync(SearchActorsCommand request);
    Task<Guid> CreateActorAsync(CreateActorCommand request);
    Task UpdateActorAsync(UpdateActorCommand request);
    Task DeleteActorAsync(Guid id);
}
