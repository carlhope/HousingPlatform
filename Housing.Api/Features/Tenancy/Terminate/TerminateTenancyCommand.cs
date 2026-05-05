using Housing.Api.Contracts.Tenancies;
using MediatR;

namespace Housing.Api.Features.Tenancy.Terminate;

public record TerminateTenancyCommand(
    Guid Id,
    DateTime EndDate
    ): IRequest<TenancyDto>;