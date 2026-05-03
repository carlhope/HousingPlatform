namespace Housing.Api.Contracts.Landlords;

public sealed record LandlordDto(
    string name,
    string contactEmail,
    string contactPhone,
    LandlordTypeDto landordType );
