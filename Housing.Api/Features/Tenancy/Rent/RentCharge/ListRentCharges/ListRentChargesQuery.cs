using MediatR;

namespace Housing.Api.Features.Tenancy.Rent.RentCharge.ListRentCharges;

public record ListRentChargesQuery(Guid TenancyId):IRequest<IResult>;