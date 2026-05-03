using MediatR;

namespace Housing.Api.Features.Tenant.Delete;

public sealed record DeleteTenantCommand(Guid Id):IRequest<IResult>;