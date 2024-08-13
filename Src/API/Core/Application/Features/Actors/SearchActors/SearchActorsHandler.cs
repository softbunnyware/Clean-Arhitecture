using Application.Features.Actors.GetActor;
using Application.Pagination;
using MediatR;

namespace Application.Features.Actors.SearchActors;

public class SearchActorsHandler : IRequestHandler<SearchActorsCommand, PaginationResponse<GetActorResponse>>
{
    private readonly IActorsService _service;

    public SearchActorsHandler(IActorsService service)
    {
        _service = service;
    }

    public async Task<PaginationResponse<GetActorResponse>> Handle(SearchActorsCommand request, CancellationToken cancellationToken)
    {
        return await _service.SearchActorsAsync(request);
    }
}