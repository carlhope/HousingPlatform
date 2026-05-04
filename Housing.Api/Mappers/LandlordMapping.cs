using Housing.Api.Contracts.Landlords;
using Housing.Domain.Entities;

namespace Housing.Api.Mappers;

public static class LandlordMapping
{
    public static LandlordDto ToDto(this Landlord landlord)
        => new(
            landlord.Name,
            landlord.ContactEmail,
            landlord.ContactPhone,
            landlord.Type.ToDto()
        );
}
