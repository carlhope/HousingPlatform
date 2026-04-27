using MediatR;
using Housing.Domain.Entities;
using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services;
using Housing.Infrastructure.Services.Interfaces;

namespace Housing.Api.Features.Properties.Create;

public class CreatePropertyHandler : IRequestHandler<CreatePropertyCommand, Guid>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;

    public CreatePropertyHandler(HousingDbContext db, ICacheService cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<Guid> Handle(CreatePropertyCommand request, CancellationToken ct)
    {
        var property = new Property(
            request.Name,
            request.Address,
            request.Bedrooms,
            request.OwnerId,
            request.LandlordId
        );

        _db.Properties.Add(property);
        await _db.SaveChangesAsync(ct);

        await _cache.RemoveAsync("properties:all");
        await _cache.RemoveAsync($"properties:landlord:{property.LandlordId}");
        await _cache.RemoveAsync($"properties:owner:{property.OwnerId}");

        return property.Id;
    }
}