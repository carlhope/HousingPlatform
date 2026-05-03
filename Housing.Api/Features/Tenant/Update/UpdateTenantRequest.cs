namespace Housing.Api.Features.Tenant.Update;

public sealed record UpdateTenantRequest(Guid Id, string FirstName, string LastName, string Email, string Phone);