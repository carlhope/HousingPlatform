using Housing.Infrastructure.Persistence;

namespace Housing.Api.Features.Properties;

public static class DeleteProperty
{
    public static RouteHandlerBuilder MapDeleteProperty(this IEndpointRouteBuilder group)
    {
        return group.MapDelete("/{id}", async (Guid id, HousingDbContext db) =>
        {
            var property = await db.Properties.FindAsync(id);
            if (property is null)
                return Results.NotFound();

            db.Properties.Remove(property);
            await db.SaveChangesAsync();

            return Results.NoContent();
        });
    }
}