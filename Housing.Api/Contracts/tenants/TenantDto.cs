namespace Housing.Api.Contracts.tenants;

public record TenantDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Phone
);