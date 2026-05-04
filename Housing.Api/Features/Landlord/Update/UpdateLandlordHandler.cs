using Housing.Api.Contracts.Landlords;
using Housing.Api.Mappers;
using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;

namespace Housing.Api.Features.Landlord.Update;

public class UpdateLandlordHandler 
    : IRequestHandler<UpdateLandlordCommand, LandlordDto>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;

    public UpdateLandlordHandler(HousingDbContext db, ICacheService cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<LandlordDto> Handle(
        UpdateLandlordCommand cmd,
        CancellationToken ct)
    {
        var landlord = await _db.Landlords.FindAsync(new object[] { cmd.Id }, ct);

        if (landlord is null)
            throw new KeyNotFoundException("Landlord not found");

        landlord.UpdateDetails(
            cmd.Name,
            cmd.ContactEmail,
            cmd.ContactPhone,
            LandlordTypeMapping.ToDomain(cmd.LandordType)
        );

        await _db.SaveChangesAsync(ct);
        
        // Invalidate caches
        await _cache.RemoveAsync($"landlord:{landlord.Id}");
        await _cache.RemoveAsync("landlords:all");
   

        return new LandlordDto(
            landlord.Name,
            landlord.ContactEmail,
            landlord.ContactPhone,
            LandlordTypeMapping.ToDto(landlord.Type)
        );
    }
}