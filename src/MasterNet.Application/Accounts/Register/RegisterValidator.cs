using FluentValidation;

namespace MasterNet.Application.Accounts.Register;


public class RegisterValidator : AbstractValidator<RegisterRequest>
{

    public RegisterValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.FullName).NotEmpty();
        RuleFor(x => x.Career).NotEmpty();
        RuleFor(x => x.UserName).NotEmpty();
    }
}