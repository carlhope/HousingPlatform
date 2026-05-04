using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;

namespace Housing.Api.Features.Landlord.Get;

public class GetLandlordHandler :IRequestHandler<GetLandlordQuery, IResult>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;

    public GetLandlordHandler(HousingDbContext db, ICacheService cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<IResult> Handle(GetLandlordQuery query, CancellationToken ct)
    {
        var key = $"landlord:{query.Id}";
        
        // Try cache
        var cached = await _cache.GetAsync<Domain.Entities.Landlord>(key);
        if (cached is not null)
            return Results.Ok(cached);

        // Fallback to DB
        var landlord = await _db.Landlords.FindAsync([query.Id], ct);
        
        // Store in cache
        await _cache.SetAsync(key, landlord, TimeSpan.FromMinutes(5));

        return landlord is not null
            ? Results.Ok(landlord)
            : Results.NotFound();
    }
}