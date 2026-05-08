using Housing.Api.Contracts.Rent;
using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Housing.Api.Features.Tenancy.Rent.GetBalance;

public class GetBalanceHandler :IRequestHandler<GetBalanceQuery, IResult>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;

    public GetBalanceHandler(HousingDbContext db, ICacheService cache)
    {
        _db = db;
        _cache = cache;
    }

    public async Task<IResult> Handle(GetBalanceQuery query, CancellationToken ct)
    {
        var key = $"balance:{query.Id}";
        
        // Try cache
        var cached = await _cache.GetAsync<TenancyBalanceDto>(key);
        if (cached is not null)
            return Results.Ok(cached);

        // Fallback to DB

       
        var chargesTask = _db.RentCharges
            .Where(x => x.TenancyId == query.Id)
            .SumAsync(x => (decimal?)x.Amount);

        var paymentsTask = _db.RentPayments
            .Where(x => x.TenancyId == query.Id)
            .SumAsync(x => (decimal?)x.Amount);

        var charges = await chargesTask ?? 0m;
        var payments = await paymentsTask ?? 0m;

        var balanceDto = new TenancyBalanceDto(payments - charges);

        
        // Store in cache
        await _cache.SetAsync(key, balanceDto, TimeSpan.FromMinutes(5));

        return balanceDto is not null
            ? Results.Ok(balanceDto)
            : Results.NotFound();
    }
}