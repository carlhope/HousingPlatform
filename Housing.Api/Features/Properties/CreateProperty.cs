using Housing.Domain.Entities;
using Housing.Infrastructure.Persistence;

namespace Housing.Api.Features.Properties;

public static class CreateProperty
{
    public static RouteHandlerBuilder MapCreateProperty(this IEndpointRouteBuilder group)
    {
        return group.MapPost("/", async (Property property, HousingDbContext db) =>
        {
            db.Properties.Add(property);
            await db.SaveChangesAsync();
            return Results.Created($"/properties/{property.Id}", property);
        });
    }
}
