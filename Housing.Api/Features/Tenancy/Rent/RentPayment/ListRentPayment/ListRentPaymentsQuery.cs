using MediatR;

namespace Housing.Api.Features.Tenancy.Rent.RentPayment.ListRentPayment;

public record ListRentPaymentsQuery(Guid TenancyId):IRequest<IResult>;