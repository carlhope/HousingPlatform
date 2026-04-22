using Housing.Infrastructure.Persistence;

namespace Housing.Api.Features.Properties;

public static class GetProperty
{
    public static RouteHandlerBuilder MapGetProperty(this IEndpointRouteBuilder group)
    {
        return group.MapGet("/{id}", async (Guid id, HousingDbContext db) =>
        {
            var property = await db.Properties.FindAsync(id);
            return property is not null ? Results.Ok(property) : Results.NotFound();
        });
    }
}