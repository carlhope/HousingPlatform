using Housing.Api.Contracts.Landlords;
using Housing.Domain.Entities;

namespace Housing.Api.Mappers;

public static class LandlordTypeMapping
{
    public static LandlordTypeDto ToDto(this LandlordType type)
        => type switch
        {
            LandlordType.HousingAssociation => LandlordTypeDto.HousingAssociation,
            LandlordType.PrivateLandlord    => LandlordTypeDto.PrivateLandlord,
            LandlordType.ManagementCompany  => LandlordTypeDto.ManagementCompany,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };

    public static LandlordType ToDomain(this LandlordTypeDto type)
        => type switch
        {
            LandlordTypeDto.HousingAssociation => LandlordType.HousingAssociation,
            LandlordTypeDto.PrivateLandlord    => LandlordType.PrivateLandlord,
            LandlordTypeDto.ManagementCompany  => LandlordType.ManagementCompany,
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
}

