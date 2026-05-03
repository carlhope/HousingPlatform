using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;

namespace Housing.Api.Features.Tenant.Create;

public class CreateTenantHandler: IRequestHandler<CreateTenantCommand, Guid>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;
    private readonly IEventPublisher _eventPublisher;

    public CreateTenantHandler(HousingDbContext db, ICacheService cache, IEventPublisher eventPublisher)
    {
        _db = db;
        _cache = cache;
        _eventPublisher = eventPublisher;
        
    }
    public async Task<Guid> Handle(CreateTenantCommand request, CancellationToken ct)
    {
        var tenant = new Domain.Entities.Tenant(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Phone
        );

        _db.Tenants.Add(tenant);
        await _db.SaveChangesAsync(ct);


        await _cache.RemoveAsync("tenants:all");
        //consider if other tables need resetting

        return tenant.Id;
    }
}
