using Microsoft.AspNetCore.Mvc;
using Server.Controllers.Base;

namespace Server.Controllers;

public class MoviesController : BaseController
{
    [HttpGet("{id:guid}")]
    public async Task GetAsync(Guid id)
    {
    }

    [HttpGet("list")]
    public async Task GetListAsync()
    {
    }

    [HttpPost("create")]
    public async Task CreateAsync()
    {
    }

    [HttpPut("update")]
    public async Task UpdateAsync()
    {
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task DeleteAsync(Guid id)
    {
    }
}
