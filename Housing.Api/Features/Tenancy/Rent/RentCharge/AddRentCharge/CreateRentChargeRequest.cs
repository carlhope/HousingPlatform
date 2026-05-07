namespace Housing.Api.Features.Tenancy.Rent.RentCharge.AddRentCharge;

public record CreateRentChargeRequest
(
    decimal Amount,
    DateTime StartDate,
    string Reason
);