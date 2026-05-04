using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Housing.Api.Features.Landlord.List;

public class ListLandlordHandler:IRequestHandler<ListLandlordQuery, IResult>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;
    private readonly ILogger<ListLandlordHandler> _logger;

    public ListLandlordHandler(HousingDbContext db, ICacheService cache, ILogger<ListLandlordHandler> logger)
    {
        _db = db;
        _cache = cache;
        _logger = logger;
    }

    public async Task<IResult> Handle(ListLandlordQuery query, CancellationToken ct)
    {
        var key = "landlords:all";

        var cached = await _cache.GetAsync<List<Domain.Entities.Landlord>>(key);
        if (cached is not null)
        {
            _logger.LogInformation("Getting landlords from cache");
            return Results.Ok(cached);
        }
        _logger.LogInformation("Getting landlords from db");
        

        var landlords = await _db.Landlords.ToListAsync(ct);
        await _cache.SetAsync(key, landlords, TimeSpan.FromMinutes(5));
        return Results.Ok(landlords);
    }
}