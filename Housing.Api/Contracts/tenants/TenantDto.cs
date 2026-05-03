namespace Housing.Api.Contracts.tenants;

public sealed record TenantDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Phone
);