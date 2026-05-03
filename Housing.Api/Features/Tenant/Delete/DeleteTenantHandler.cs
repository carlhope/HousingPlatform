using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;

namespace Housing.Api.Features.Tenant.Delete;

public class DeleteTenantHandler: IRequestHandler<DeleteTenantCommand, IResult>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;

    public DeleteTenantHandler(HousingDbContext db, ICacheService cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<IResult> Handle(DeleteTenantCommand command, CancellationToken ct)
    {
        Domain.Entities.Tenant tenant = await _db.Tenants.FindAsync([command.Id], ct);
        if (tenant is null)
            return Results.NotFound();

        tenant.SoftDelete();
        await _db.SaveChangesAsync(ct);
            
        // Invalidate caches
        await _cache.RemoveAsync($"tenants:{tenant.Id}");
        await _cache.RemoveAsync("tenants:all");
        //review if other tables should be refreshed

        return Results.NoContent();
    }
}