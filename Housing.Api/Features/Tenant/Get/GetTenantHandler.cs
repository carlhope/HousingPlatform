using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;

namespace Housing.Api.Features.Tenant.Get;


public class GetPropertyHandler :IRequestHandler<GetTenantQuery, IResult>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;

    public GetPropertyHandler(HousingDbContext db, ICacheService cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<IResult> Handle(GetTenantQuery query, CancellationToken ct)
    {
        var key = $"tenants:{query.Id}";
        
        // Try cache
        var cached = await _cache.GetAsync<Domain.Entities.Tenant>(key);
        if (cached is not null)
            return Results.Ok(cached);

        // Fallback to DB
        var tenant = await _db.Tenants.FindAsync([query.Id], ct);
        
        // Store in cache
        await _cache.SetAsync(key, tenant, TimeSpan.FromMinutes(5));

        return tenant is not null
            ? Results.Ok(tenant)
            : Results.NotFound();
    }
}