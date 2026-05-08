namespace Housing.Api.Features.Tenancy.Rent.RentPayment.AddRentPayment;

public record CreateRentPaymentRequest
(
    decimal Amount,
    string Reference
);