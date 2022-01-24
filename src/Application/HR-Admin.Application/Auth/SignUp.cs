using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using Admin_HR.Infrastructure.Dtos.User;
using FluentValidation;
using HR_Admin.Application.Core;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HR_Admin.Application.Auth
{
    public class SignUp
    {
        public class Command : IRequest<Result<Unit>>
        {
            public SignUpDto SignUpDto { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator() => RuleFor(x => x.SignUpDto).SetValidator(new SignUpValidator());
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly UserManager<User> _userManager;

            public Handler(UserManager<User> userManager)
                => _userManager = userManager;
            
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                // await _userManager.
                
                return Result<Unit>.Success(Unit.Value);
            }
        }

    }
}