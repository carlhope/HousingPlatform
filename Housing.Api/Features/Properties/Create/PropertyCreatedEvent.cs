using MediatR;

namespace Housing.Api.Features.Properties.Create;

public sealed record PropertyCreatedEvent(Guid PropertyId, DateTime CreatedAt):INotification;
