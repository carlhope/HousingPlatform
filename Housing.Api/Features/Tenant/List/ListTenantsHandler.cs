using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Housing.Api.Features.Tenant.Get;

public class ListTenantsHandler:IRequestHandler<ListTenantsQuery, IResult>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;
    private readonly ILogger<ListTenantsHandler> _logger;

    public ListTenantsHandler(HousingDbContext db, ICacheService cache, ILogger<ListTenantsHandler> logger)
    {
        _db = db;
        _cache = cache;
        _logger = logger;
    }

    public async Task<IResult> Handle(ListTenantsQuery query, CancellationToken ct)
    {
        var key = "tenants:all";

        var cached = await _cache.GetAsync<List<Domain.Entities.Tenant>>(key);
        if (cached is not null)
        {
            _logger.LogInformation("Getting tenants from cache");
            return Results.Ok(cached);
        }
        _logger.LogInformation("Getting tenants from db");
        

        var tenants = await _db.Tenants.ToListAsync(ct);
        await _cache.SetAsync(key, tenants, TimeSpan.FromMinutes(5));
        return Results.Ok(tenants);
    }
}