namespace Housing.Api.Contracts.Rent;

public sealed record RentChargeDto(
    
    decimal Amount,
    DateTime StartDate,
    DateTime? EndDate
);
