using Housing.Api.Contracts.Tenancies;
using Housing.Api.Mappers;
using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Housing.Api.Features.Tenancy.Get;

public class GetTenancyHandler :IRequestHandler<GetTenancyQuery, IResult>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;

    public GetTenancyHandler(HousingDbContext db, ICacheService cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<IResult> Handle(GetTenancyQuery query, CancellationToken ct)
    {
        var key = $"tenancy:{query.Id}";
        
        // Try cache
        var cached = await _cache.GetAsync<TenancyDto>(key);
        if (cached is not null)
            return Results.Ok(cached);

        // Fallback to DB
        var tenancy = await _db.Tenancies
            .Include(t => t.Landlord)
            .Include(t => t.Property)
            .Include(t => t.Tenants).FirstAsync();
        var tenancyDto = tenancy.ToDto();
        
        // Store in cache
        await _cache.SetAsync(key, tenancyDto, TimeSpan.FromMinutes(5));

        return tenancyDto is not null
            ? Results.Ok(tenancyDto)
            : Results.NotFound();
    }
}