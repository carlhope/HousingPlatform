using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Housing.Api.Features.Tenancy.Rent.RentPayment.AddRentPayment;

public class CreateRentPaymentHandler: IRequestHandler<CreateRentPaymentCommand, Guid>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;
    private readonly IEventPublisher _eventPublisher;

    public CreateRentPaymentHandler(HousingDbContext db, ICacheService cache, IEventPublisher eventPublisher)
    {
        _db = db;
        _cache = cache;
        _eventPublisher = eventPublisher;
    }

    public async Task<Guid> Handle(CreateRentPaymentCommand request, CancellationToken ct)
    {
        var tenancy = await _db.Tenancies
            .Include(t => t.RentHistory)
            .FirstOrDefaultAsync(t => t.Id == request.TenancyId, ct);
        if (tenancy == null) throw new InvalidOperationException();
        tenancy.AddRentPayment(request.Amount, request.Reference);
        await _db.SaveChangesAsync(ct);


        await _cache.RemoveAsync($"rentcharges:{request.TenancyId}");


        return request.TenancyId;
    }
}