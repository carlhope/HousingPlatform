using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Housing.Api.Features.Owner.List;

public class ListOwnerHandler:IRequestHandler<ListOwnerQuery, IResult>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;
    private readonly ILogger<ListOwnerHandler> _logger;

    public ListOwnerHandler(HousingDbContext db, ICacheService cache, ILogger<ListOwnerHandler> logger)
    {
        _db = db;
        _cache = cache;
        _logger = logger;
    }

    public async Task<IResult> Handle(ListOwnerQuery query, CancellationToken ct)
    {
        var key = "owners:all";

        var cached = await _cache.GetAsync<List<Domain.Entities.Owner>>(key);
        if (cached is not null)
        {
            _logger.LogInformation("Getting owners from cache");
            return Results.Ok(cached);
        }
        _logger.LogInformation("Getting owners from db");
        

        var owners = await _db.Owners.ToListAsync(ct);
        await _cache.SetAsync(key, owners, TimeSpan.FromMinutes(5));
        return Results.Ok(owners);
    }
}