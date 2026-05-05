namespace Housing.Api.Features.Tenancy.Terminate;

public record TerminateTenancyRequest(Guid id, DateTime endDate);