using Application.Pagination;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Pagination;

public static class PaginationExtensions
{
    public static async Task<PaginationResponse<Z>> ToPagedListAsync<T, Z>(this IQueryable<T> source, int page, int pageSize, CancellationToken token = default)
    {
        var count = await source.CountAsync(token);

        if (count > 0)
        {
            var items = await source
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(token);
            return new PaginationResponse<Z>(items.Adapt<List<Z>>(), count, page, pageSize);
        }

        return new(new List<Z>(), 0, 0, 0);
    }
}
