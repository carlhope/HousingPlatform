using FluentValidation;

namespace Housing.Api.Features.Tenant.Delete;

public sealed class DeleteTenantValidator : AbstractValidator<DeleteTenantCommand>
{
    public DeleteTenantValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}