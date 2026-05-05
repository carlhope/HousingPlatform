using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Housing.Api.Features.Tenancy.Create;

public class CreateTenancyHandler: IRequestHandler<CreateTenancyCommand, Guid>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;
    private readonly IEventPublisher _eventPublisher;

    public CreateTenancyHandler(HousingDbContext db, ICacheService cache, IEventPublisher eventPublisher)
    {
        _db = db;
        _cache = cache;
        _eventPublisher = eventPublisher;
    }

    public async Task<Guid> Handle(CreateTenancyCommand request, CancellationToken ct)
    {

        var property = await _db.Properties
            .Include(p => p.Tenancies)
            .FirstOrDefaultAsync(p => p.Id == request.PropertyId);
        if (property.LandlordId != request.LandlordId) throw new Exception("Invalid landlord");
        foreach (Domain.Entities.Tenancy t in property.Tenancies)
        {
            if (t.EndDate == null || t.EndDate >= request.StartDate)
            {
                throw new Exception("Tenancy already exists");
            }
        }
        var tenants = await _db.Tenants
            .Where(t => request.TenantIds.Contains(t.Id))
            .ToListAsync(ct);

        if (tenants.Count!=request.TenantIds.Count) throw new ApplicationException("One or more tenants not found");
        var tenancy = new Domain.Entities.Tenancy(
           request.PropertyId,
           request.LandlordId,
           request.StartDate,
           tenants
        );

        _db.Tenancies.Add(tenancy);
        await _db.SaveChangesAsync(ct);


        await _cache.RemoveAsync("tenancies:all");

        return tenancy.Id;
    }
}