using Housing.Api.Contracts.Landlords;

namespace Housing.Api.Features.Landlord.Create;

public record CreateLandlordRequest(
    string Name,
    string Email,
    string Phone,
    LandlordTypeDto LandlordType);