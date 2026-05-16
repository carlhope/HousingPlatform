using Housing.Contracts.Events.Properties;
using MediatR;
using Housing.Domain.Entities;
using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;

namespace Housing.Api.Features.Properties.Create;

public class CreatePropertyHandler : IRequestHandler<CreatePropertyCommand, Guid>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;
    private readonly IEventPublisher _eventPublisher;

    public CreatePropertyHandler(HousingDbContext db, ICacheService cache, IEventPublisher eventPublisher)
    {
        _db = db;
        _cache = cache;
        _eventPublisher = eventPublisher;
    }

    public async Task<Guid> Handle(CreatePropertyCommand request, CancellationToken ct)
    {
        var property = new Property(
            request.Name,
            request.Address,
            request.Bedrooms,
            request.OwnerId,
            request.LandlordId
        );

        _db.Properties.Add(property);
        await _db.SaveChangesAsync(ct);
        
        //basic RabbitMQ implementation.
        //proof of concept whilst project scope remains limited
        await _eventPublisher.PublishAsync(new PropertyCreatedEvent(
            property.Id,
            property.LandlordId,
            property.OwnerId,
            property.CreatedAt
        ));


        await _cache.RemoveAsync("properties:all");
        await _cache.RemoveAsync($"properties:landlord:{property.LandlordId}");
        await _cache.RemoveAsync($"properties:owner:{property.OwnerId}");

        return property.Id;
    }
}