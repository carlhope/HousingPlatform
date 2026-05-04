using Housing.Api.Contracts.Landlords;
using MediatR;

namespace Housing.Api.Features.Landlord.Create;

public record CreateLandlordCommand(
   string Name,
   string Email,
   string Phone,
   LandlordTypeDto LandlordType
) : IRequest<Guid>;