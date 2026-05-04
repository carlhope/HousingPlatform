using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;

namespace Housing.Api.Features.Owner.Create;

public class CreateOwnerHandler: IRequestHandler<CreateOwnerCommand, Guid>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;
    private readonly IEventPublisher _eventPublisher;

    public CreateOwnerHandler(HousingDbContext db, ICacheService cache, IEventPublisher eventPublisher)
    {
        _db = db;
        _cache = cache;
        _eventPublisher = eventPublisher;
    }

    public async Task<Guid> Handle(CreateOwnerCommand request, CancellationToken ct)
    {
        var owner = new Domain.Entities.Owner(
            request.Name,
            request.Email,
            request.Phone);

        _db.Owners.Add(owner);
        await _db.SaveChangesAsync(ct);


        await _cache.RemoveAsync("owners:all");

        return owner.Id;
    }
}