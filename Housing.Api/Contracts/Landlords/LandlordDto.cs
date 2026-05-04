namespace Housing.Api.Contracts.Landlords;

public sealed record LandlordDto(
    string Name,
    string ContactEmail,
    string ContactPhone,
    LandlordTypeDto LandlordType );
