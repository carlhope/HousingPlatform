using Housing.Domain.Entities;
using Housing.Infrastructure.Persistence;

namespace Housing.Api.Features.Properties;

public static class UpdateProperty
{
    public static RouteHandlerBuilder MapUpdateProperty(this IEndpointRouteBuilder group)
    {
        return group.MapPut("/{id}", async (Guid id, Property updated, HousingDbContext db) =>
        {
            var property = await db.Properties.FindAsync(id);
            if (property is null)
                return Results.NotFound();
            
            property.Address = updated.Address;
            property.Bedrooms = updated.Bedrooms;
            property.Rent = updated.Rent;

            await db.SaveChangesAsync();

            return Results.Ok(property);
        });
    }
}
