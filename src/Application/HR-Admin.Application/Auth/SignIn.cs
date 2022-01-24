using HR_Admin.Application.Core;
using MediatR;
using FluentValidation;
using HR_Admin.Application.Core;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using Admin_HR.Infrastructure.Dtos.User;
using HR_Admin.Application.Departments;

namespace HR_Admin.Application.Auth
{
    public class SignIn
    {
        public class Command : IRequest<Result<UserDto>>
        {
            public SignInDto SignInDto { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
                => RuleFor(x => x.SignInDto).SetValidator(new SignInValidator());
        }

        public class Handler : IRequestHandler<Command, Result<UserDto>>
        {
            private readonly UserManager<User> _userManager;
            private readonly SignInManager<User> _signInManager;

            public Handler(UserManager<User> userManager, SignInManager<User> signInManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
            }
            
            // public Task<Result<Unit>> Handle(Create.Command request, CancellationToken cancellationToken)
            // {
            //     var user = await _userManager.FindByEmailAsync(request.);
            // }

            public async Task<Result<UserDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.SignInDto.Email);

                if (user == null) return null;

                var result = await _signInManager.CheckPasswordSignInAsync(user, request.SignInDto.Password, false);

                if (!result.Succeeded) return null;

                var newUser = new UserDto()
                {
                    Name = user.Name,
                    Username = user.UserName,
                    Token = "sfjnsdln2324324sada!0sfsd322"
                };

                return Result<UserDto>.Success(newUser);
            }
        }



    }
}