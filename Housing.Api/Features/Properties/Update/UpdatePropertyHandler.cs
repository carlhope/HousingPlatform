using Housing.Api.Contracts.Properties;
using Housing.Contracts.Events.Properties;
using Housing.Infrastructure.Persistence;
using Housing.Infrastructure.Services.Interfaces;
using MediatR;

namespace Housing.Api.Features.Properties.Update;

public class UpdatePropertyHandler 
    : IRequestHandler<UpdatePropertyCommand, PropertyDto>
{
    private readonly HousingDbContext _db;
    private readonly ICacheService _cache;
    private readonly IEventPublisher _eventPublisher;

    public UpdatePropertyHandler(HousingDbContext db, ICacheService cache, IEventPublisher eventPublisher)
    {
        _db = db;
        _cache = cache;
        _eventPublisher = eventPublisher;
    }

    public async Task<PropertyDto> Handle(
        UpdatePropertyCommand cmd,
        CancellationToken ct)
    {
        var property = await _db.Properties.FindAsync(new object[] { cmd.Id }, ct);

        if (property is null)
            throw new KeyNotFoundException("Property not found");

        property.UpdateDetails(
            cmd.Name,
            cmd.Address,
            cmd.Bedrooms
        );

        await _db.SaveChangesAsync(ct);
        
        //basic RabbitMQ implementation.
        //proof of concept whilst project scope remains limited
        await _eventPublisher.PublishAsync(new PropertyUpdatedEvent(
            property.Id,
            property.LandlordId,
            property.OwnerId
        ));

        return new PropertyDto(
            property.Id,
            property.Name,
            property.Address,
            property.Bedrooms
        );
    }
}