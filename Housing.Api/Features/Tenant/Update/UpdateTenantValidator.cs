using FluentValidation;

namespace Housing.Api.Features.Tenant.Update;

public sealed class UpdatePropertyValidator : AbstractValidator<UpdateTenantCommand>
{
    public UpdatePropertyValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Phone).NotEmpty();
        //improve email and phone with regex
    }

    
}