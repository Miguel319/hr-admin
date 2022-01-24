using Admin_HR.Infrastructure.Dtos.User;
using FluentValidation;

namespace HR_Admin.Application.Auth
{
    public class SignInValidator : AbstractValidator<SignInDto>
    {
        public SignInValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}