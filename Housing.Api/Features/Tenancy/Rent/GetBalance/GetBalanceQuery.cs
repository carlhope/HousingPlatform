using MediatR;

namespace Housing.Api.Features.Tenancy.Rent.GetBalance;

public record GetBalanceQuery(Guid Id):IRequest<IResult>;