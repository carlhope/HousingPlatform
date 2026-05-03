namespace Housing.Api.Features.Tenant.Update;

public record UpdateTenantRequest(Guid Id, string FirstName, string LastName, string Email, string Phone);