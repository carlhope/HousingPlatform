using Housing.Api.Contracts.Rent;
using Housing.Domain.Entities;

namespace Housing.Api.Mappers;

public static class RentChargeMapping
{
    public static RentChargeDto ToDto(this RentCharge charge)
        => new(
            charge.Amount,
            charge.StartDate,
            charge.EndDate
        );
    


}