using Housing.Domain.Entities;
using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Housing.Api.Features.Properties.Get;

public class GetPropertyHandler :IRequestHandler<GetPropertyQuery, IResult>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;

    public GetPropertyHandler(HousingDbContext db, ICacheService cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<IResult> Handle(GetPropertyQuery query, CancellationToken ct)
    {
        var key = $"property:{query.Id}";
        
        // Try cache
        var cached = await _cache.GetAsync<Property>(key);
        if (cached is not null)
            return Results.Ok(cached);

        // Fallback to DB
        var property = await _db.Properties.FindAsync([query.Id], ct);
        
        // Store in cache
        await _cache.SetAsync(key, property, TimeSpan.FromMinutes(5));

        return property is not null
            ? Results.Ok(property)
            : Results.NotFound();
    }
}



