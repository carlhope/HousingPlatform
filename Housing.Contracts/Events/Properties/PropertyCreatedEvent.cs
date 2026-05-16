using MediatR;

namespace Housing.Contracts.Events.Properties;

public sealed record PropertyCreatedEvent(
    Guid PropertyId,
    Guid LandlordId,
    Guid OwnerId,
    DateTime CreatedAt
    ):INotification;
