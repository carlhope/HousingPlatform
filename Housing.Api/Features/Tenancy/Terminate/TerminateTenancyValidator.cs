using FluentValidation;

namespace Housing.Api.Features.Tenancy.Terminate;

public class TerminateTenancyValidator : AbstractValidator<TerminateTenancyCommand>
{
    public TerminateTenancyValidator()
    {
        RuleFor(x=>x.Id).NotNull();
        RuleFor(x=>x.EndDate).NotNull();
    }

    
}