using MediatR;

namespace Housing.Api.Features.Properties.Create;

public record PropertyCreatedEvent(Guid PropertyId, DateTime CreatedAt):INotification;
