using Housing.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Housing.Api.Features.Properties;

public static class ListProperties
{
    public static RouteHandlerBuilder MapListProperties(this IEndpointRouteBuilder group)
    {
        return group.MapGet("/", async (HousingDbContext db) =>
        {
            return await db.Properties.ToListAsync();
        });
    }
}
