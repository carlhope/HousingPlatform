using Housing.Api.Contracts.tenants;
using Housing.Domain.Entities;

namespace Housing.Api.Mappers;

public static class TenantMapping
{
    public static TenantDto ToDto(this Tenant tenant)
        => new(
            tenant.Id,
            tenant.FirstName,
            tenant.LastName,
            tenant.Email,
            tenant.Phone
        );
}
