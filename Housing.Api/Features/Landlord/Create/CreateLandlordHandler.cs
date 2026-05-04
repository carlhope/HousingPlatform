using Housing.Api.Mappers;
using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;

namespace Housing.Api.Features.Landlord.Create;

public class CreateLandlordHandler: IRequestHandler<CreateLandlordCommand, Guid>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;
    private readonly IEventPublisher _eventPublisher;

    public CreateLandlordHandler(HousingDbContext db, ICacheService cache, IEventPublisher eventPublisher)
    {
        _db = db;
        _cache = cache;
        _eventPublisher = eventPublisher;
    }

    public async Task<Guid> Handle(CreateLandlordCommand request, CancellationToken ct)
    {
        var landlord = new Domain.Entities.Landlord(
            request.Name,
            request.Email,
            request.Phone,
            LandlordTypeMapping.ToDomain(request.LandlordType)
        
        );

        _db.Landlords.Add(landlord);
        await _db.SaveChangesAsync(ct);


        await _cache.RemoveAsync("landlords:all");

        return landlord.Id;
    }
}