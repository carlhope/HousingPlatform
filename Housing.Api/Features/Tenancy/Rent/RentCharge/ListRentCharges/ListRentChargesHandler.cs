using Housing.Api.Contracts.Rent;
using Housing.Api.Mappers;
using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Housing.Api.Features.Tenancy.Rent.RentCharge.ListRentCharges;

public class ListRentChargesHandler:IRequestHandler<ListRentChargesQuery, IResult>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;
    private readonly ILogger<ListRentChargesHandler> _logger;

    public ListRentChargesHandler(HousingDbContext db, ICacheService cache, ILogger<ListRentChargesHandler> logger)
    {
        _db = db;
        _cache = cache;
        _logger = logger;
    }

    public async Task<IResult> Handle(ListRentChargesQuery query, CancellationToken ct)
    {
        var key = $"rentcharges:{query.TenancyId}";

        var cached = await _cache.GetAsync<List<RentChargeDto>>(key);
        if (cached is not null)
        {
            _logger.LogInformation("Getting RentCharges from cache");
            return Results.Ok(cached);
        }
        _logger.LogInformation("Getting RentCharges from db");


        var rentCharges = await _db.RentCharges
            .Where(x => x.TenancyId == query.TenancyId)
            .OrderBy(x => x.StartDate)
            .ToListAsync(ct);
        List<RentChargeDto> rentChargeDto = rentCharges.Select(t => t.ToDto()).ToList();
        await _cache.SetAsync(key, rentChargeDto, TimeSpan.FromMinutes(5));
        return Results.Ok(rentChargeDto);
    }
}