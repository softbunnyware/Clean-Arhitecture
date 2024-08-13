using Application.Features.Actors.GetActor;
using Application.Pagination;
using MediatR;

namespace Application.Features.Actors.SearchActors;

public class SearchActorsCommand : PaginationFilter, IRequest<PaginationResponse<GetActorResponse>>
{
}
