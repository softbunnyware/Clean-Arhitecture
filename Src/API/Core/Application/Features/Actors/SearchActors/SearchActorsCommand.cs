using Application.Features.Actors.GetActor;
using MediatR;

namespace Application.Features.Actors.SearchActors;

public class SearchActorsCommand : IRequest<List<GetActorResponse>>
{
}
