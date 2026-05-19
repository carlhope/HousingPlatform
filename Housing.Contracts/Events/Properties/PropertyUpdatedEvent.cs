using MediatR;

namespace Housing.Contracts.Events.Properties;

public record PropertyUpdatedEvent(
    Guid PropertyId,
    Guid LandlordId,
    Guid OwnerId
    ):INotification;