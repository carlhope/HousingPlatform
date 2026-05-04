using Housing.Api.Contracts.Tenancies;
using Housing.Domain.Entities;

namespace Housing.Api.Mappers;


    public static class TenancyMapping
    {
        public static TenancyDto ToDto(this Tenancy tenancy)
            => new(
                tenancy.Id,
                tenancy.PropertyId,
                tenancy.Property.ToDto(),
                tenancy.Tenants.Select(t => t.ToDto()).ToList(),
                tenancy.LandlordId,
                tenancy.Landlord.ToDto(),
                tenancy.StartDate,
                tenancy.EndDate,
                tenancy.RentHistory.Select(rc => rc.ToDto()).ToList(),
                tenancy.Payments.Select(p => p.ToDto()).ToList()
            );
    }
    