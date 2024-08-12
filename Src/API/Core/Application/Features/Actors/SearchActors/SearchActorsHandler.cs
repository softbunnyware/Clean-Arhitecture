using Application.Features.Actors.GetActor;
using MediatR;

namespace Application.Features.Actors.SearchActors;

public class SearchActorsHandler : IRequestHandler<SearchActorsCommand, List<GetActorResponse>>
{
    private readonly IActorsService _service;

    public SearchActorsHandler(IActorsService service)
    {
        _service = service;
    }

    public async Task<List<GetActorResponse>> Handle(SearchActorsCommand request, CancellationToken cancellationToken)
    {
        return await _service.SearchActorsAsync();
    }
}