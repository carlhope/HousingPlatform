using Housing.Api.Contracts.Tenancies;
using Housing.Api.Mappers;
using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Housing.Api.Features.Tenancy.List;

public class ListTenanciesHandler:IRequestHandler<ListTenanciesQuery, IResult>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;
    private readonly ILogger<ListTenanciesHandler> _logger;

    public ListTenanciesHandler(HousingDbContext db, ICacheService cache, ILogger<ListTenanciesHandler> logger)
    {
        _db = db;
        _cache = cache;
        _logger = logger;
    }

    public async Task<IResult> Handle(ListTenanciesQuery query, CancellationToken ct)
    {
        var key = "tenancies:all";

        var cached = await _cache.GetAsync<List<TenancyDto>>(key);
        if (cached is not null)
        {
            _logger.LogInformation("Getting tenancies from cache");
            return Results.Ok(cached);
        }
        _logger.LogInformation("Getting tenancies from db");
        

        var tenancies = await _db.Tenancies
            .Include(t => t.Landlord)
            .Include(t => t.Property)
            .Include(t=>t.Tenants)
            .ToListAsync(ct);
        List<TenancyDto> tenanciesDto = tenancies.Select(t => t.ToDto()).ToList();
        await _cache.SetAsync(key, tenanciesDto, TimeSpan.FromMinutes(5));
        return Results.Ok(tenanciesDto);
    }
}