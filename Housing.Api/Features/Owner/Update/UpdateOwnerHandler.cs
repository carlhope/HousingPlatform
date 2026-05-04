using Housing.Api.Contracts.Owners;
using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;

namespace Housing.Api.Features.Owner.Update;

public class UpdateOwnerHandler 
    : IRequestHandler<UpdateOwnerCommand, OwnerDto>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;

    public UpdateOwnerHandler(HousingDbContext db, ICacheService cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<OwnerDto> Handle(
        UpdateOwnerCommand cmd,
        CancellationToken ct)
    {
        var owner = await _db.Owners.FindAsync(new object[] { cmd.Id }, ct);

        if (owner is null)
            throw new KeyNotFoundException("Owner not found");

        owner.UpdateDetails(
            cmd.Name,
            cmd.ContactEmail,
            cmd.ContactPhone
        );

        await _db.SaveChangesAsync(ct);
        
        // Invalidate caches
        await _cache.RemoveAsync($"owner:{owner.Id}");
        await _cache.RemoveAsync("owner:all");
   

        return new OwnerDto(
            owner.Name,
            owner.ContactEmail,
            owner.ContactPhone
        );
    }
}