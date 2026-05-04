using Housing.Api.Contracts.Properties;
using Housing.Domain.Entities;

namespace Housing.Api.Mappers;

public static class PropertyMapping
{
    public static PropertyDto ToDto(this Property property)
        => new(
            property.Id,
            property.Name,
            property.Address,
            property.Bedrooms
        );
}