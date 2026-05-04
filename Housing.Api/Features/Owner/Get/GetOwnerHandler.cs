using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;

namespace Housing.Api.Features.Owner.Get;

public class GetOwnerHandler :IRequestHandler<GetOwnerQuery, IResult>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;

    public GetOwnerHandler(HousingDbContext db, ICacheService cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<IResult> Handle(GetOwnerQuery query, CancellationToken ct)
    {
        var key = $"owner:{query.Id}";
        
        // Try cache
        var cached = await _cache.GetAsync<Domain.Entities.Owner>(key);
        if (cached is not null)
            return Results.Ok(cached);

        // Fallback to DB
        var owner = await _db.Owners.FindAsync([query.Id], ct);
        
        // Store in cache
        await _cache.SetAsync(key, owner, TimeSpan.FromMinutes(5));

        return owner is not null
            ? Results.Ok(owner)
            : Results.NotFound();
    }
}