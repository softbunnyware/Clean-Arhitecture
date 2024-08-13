using Application.Features.Movies.CreateMovie;
using Application.Features.Movies.DeleteMovie;
using Application.Features.Movies.GetMovie;
using Application.Features.Movies.SearchMovies;
using Application.Features.Movies.UpdateMovie;
using Application.Pagination;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers.Base;

namespace Server.Controllers;

public class MoviesController : BaseController
{
    [HttpGet("{id:guid}")]
    public async Task<GetMovieResponse> GetAsync(Guid id)
    {
        return await Mediator.Send(new GetMovieCommand(id));
    }

    [HttpGet("search")]
    public async Task<PaginationResponse<GetMovieResponse>> SearchAsync([FromQuery] SearchMoviesCommand query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost("create")]
    public async Task<Guid> CreateAsync(CreateMovieCommand request)
    {
        return await Mediator.Send(request);
    }

    [HttpPut("update")]
    public async Task UpdateAsync(UpdateMovieCommand request)
    {
        await Mediator.Send(request);
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task DeleteAsync(Guid id)
    {
        await Mediator.Send(new DeleteMovieCommand(id));
    }
}
