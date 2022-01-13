using System;
using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using Admin_HR.Infrastructure.Persistence;
using FluentValidation;
using HR_Admin.Application.Core;
using MediatR;

namespace HR_Admin.Application.Departments
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Department Department { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
                => RuleFor(x => x.Department).SetValidator(new DepartmentValidator());
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
                => _context = context;
            
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                request.Department.CreatedAt = DateTime.Now;
                request.Department.UpdatedAt = DateTime.Now;
                
                 _context.Departments.Add(request.Department);

                bool result = await _context.SaveChangesAsync(cancellationToken) > 0;

                if (!result) return Result<Unit>.Failure("Failed to create department.");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}