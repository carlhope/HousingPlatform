using MediatR;

namespace Housing.Api.Features.Tenant.Delete;

public record DeleteTenantCommand(Guid Id):IRequest<IResult>;