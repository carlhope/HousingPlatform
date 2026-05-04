using Housing.Api.Contracts.Landlords;
using Housing.Domain.Entities;

namespace Housing.Api.Mappers;

public static class LandlordTypeMapping
{
    public static LandlordTypeDto ToDto(this LandlordType type)
        => (LandlordTypeDto)type;

    public static LandlordType ToDomain(this LandlordTypeDto type)
        => (LandlordType)type;
}
