using Housing.Api.Contracts.Landlords;

namespace Housing.Api.Features.Landlord.Update;

public record UpdateLandlordRequest(string Name, string email, string phone, LandlordTypeDto LandlordType );