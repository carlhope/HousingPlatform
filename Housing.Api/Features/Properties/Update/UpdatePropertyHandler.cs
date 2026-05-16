using Housing.Api.Contracts.Properties;
using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;

namespace Housing.Api.Features.Properties.Update;

public class UpdatePropertyHandler 
    : IRequestHandler<UpdatePropertyCommand, PropertyDto>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;

    public UpdatePropertyHandler(HousingDbContext db, ICacheService cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<PropertyDto> Handle(
        UpdatePropertyCommand cmd,
        CancellationToken ct)
    {
        var property = await _db.Properties.FindAsync(new object[] { cmd.Id }, ct);

        if (property is null)
            throw new KeyNotFoundException("Property not found");

        property.UpdateDetails(
            cmd.Name,
            cmd.Address,
            cmd.Bedrooms
        );

        await _db.SaveChangesAsync(ct);
        
        // Invalidate caches
        await _cache.RemoveAsync($"property:{property.Id}");
        await _cache.RemoveAsync("properties:all");
        await _cache.RemoveAsync($"properties:landlord:{property.LandlordId}");
        await _cache.RemoveAsync($"properties:owner:{property.OwnerId}");

        return new PropertyDto(
            property.Id,
            property.Name,
            property.Address,
            property.Bedrooms
        );
    }
}