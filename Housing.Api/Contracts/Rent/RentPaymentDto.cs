namespace Housing.Api.Contracts.Rent;

public sealed record RentPaymentDto(
    
    decimal Amount,
    DateTime PaidOn,
    string? Reference
);

