using Housing.Domain.Entities;
using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Housing.Api.Features.Properties.List;

public class ListPropertiesHandler:IRequestHandler<ListPropertiesQuery, IResult>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;
    private readonly ILogger<ListPropertiesHandler> _logger;

    public ListPropertiesHandler(HousingDbContext db, ICacheService cache, ILogger<ListPropertiesHandler> logger)
    {
        _db = db;
        _cache = cache;
        _logger = logger;
    }

    public async Task<IResult> Handle(ListPropertiesQuery query, CancellationToken ct)
    {
        var key = "properties:all";

        var cached = await _cache.GetAsync<List<Property>>(key);
        if (cached is not null)
        {
            _logger.LogInformation("Getting properties from cache");
            return Results.Ok(cached);
        }
        _logger.LogInformation("Getting properties from db");
        

        var properties = await _db.Properties.ToListAsync(ct);
        await _cache.SetAsync(key, properties, TimeSpan.FromMinutes(5));
        return Results.Ok(properties);
    }
}

