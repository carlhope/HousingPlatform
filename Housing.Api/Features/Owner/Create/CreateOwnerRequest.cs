namespace Housing.Api.Features.Owner.Create;

public record CreateOwnerRequest(
    string Name,
    string Email,
    string Phone);