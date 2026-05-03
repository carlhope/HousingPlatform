namespace Housing.Api.Features.Tenant.Create;

public sealed record CreateTenantRequest(
    string FirstName,
    string LastName,
    string Email,
    string Phone
);