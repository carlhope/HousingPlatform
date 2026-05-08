using Housing.Api.Contracts.Rent;
using Housing.Api.Mappers;
using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Housing.Api.Features.Tenancy.Rent.RentPayment.ListRentPayment;

public class ListRentPaymentsHandler:IRequestHandler<ListRentPaymentsQuery, IResult>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;
    private readonly ILogger<ListRentPaymentsHandler> _logger;

    public ListRentPaymentsHandler(HousingDbContext db, ICacheService cache, ILogger<ListRentPaymentsHandler> logger)
    {
        _db = db;
        _cache = cache;
        _logger = logger;
    }

    public async Task<IResult> Handle(ListRentPaymentsQuery query, CancellationToken ct)
    {
        var key = $"rentpayments:{query.TenancyId}";

        var cached = await _cache.GetAsync<List<RentPaymentDto>>(key);
        if (cached is not null)
        {
            _logger.LogInformation("Getting RentPayments from cache");
            return Results.Ok(cached);
        }
        _logger.LogInformation("Getting RentPayments from db");


        var rentPayments = await _db.RentPayments
            .Where(x => x.TenancyId == query.TenancyId)
            .OrderBy(x => x.PaidOn)
            .ToListAsync(ct);
        List<RentPaymentDto> rentPaymentDto = rentPayments.Select(t => t.ToDto()).ToList();
        await _cache.SetAsync(key, rentPaymentDto, TimeSpan.FromMinutes(5));
        return Results.Ok(rentPaymentDto);
    }
}