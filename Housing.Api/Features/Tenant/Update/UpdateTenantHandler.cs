using Housing.Api.Contracts.tenants;
using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;

namespace Housing.Api.Features.Tenant.Update;

public class UpdateTenantHandler 
    : IRequestHandler<UpdateTenantCommand, TenantDto>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;

    public UpdateTenantHandler(HousingDbContext db, ICacheService cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<TenantDto> Handle(
        UpdateTenantCommand cmd,
        CancellationToken ct)
    {
        var tenant = await _db.Tenants.FindAsync(new object[] { cmd.Id }, ct);

        if (tenant is null)
            throw new KeyNotFoundException("Tenant not found");

        tenant.UpdateDetails(
            cmd.FirstName,
            cmd.LastName,
            cmd.Email,
            cmd.Phone
        );

        await _db.SaveChangesAsync(ct);
        
        // Invalidate caches
        await _cache.RemoveAsync($"tenants:{tenant.Id}");
        await _cache.RemoveAsync("tenants:all");
        //consider other tables that need refresh

        return new TenantDto(
            tenant.Id,
            tenant.FirstName,
            tenant.LastName,
            tenant.Email,
            tenant.Phone
        );
    }
}