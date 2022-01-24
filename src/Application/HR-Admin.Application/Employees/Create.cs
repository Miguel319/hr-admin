using System;
using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using Admin_HR.Infrastructure.Persistence;
using FluentValidation;
using HR_Admin.Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR_Admin.Application.Employees
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Employee Employee { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
                => RuleFor(x => x.Employee).SetValidator(new EmployeeValidator());
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
                => _context = context;

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var department = await _context.Departments.FirstOrDefaultAsync(
                    x => x.Id == request.Employee.Department.Id,
                    cancellationToken);

                if (department == null) return null;

                var position = await _context.Positions.FirstOrDefaultAsync(x => x.Id == request.Employee.Position.Id,
                    cancellationToken);

                if (position == null) return null;

                request.Employee.CreatedAt = DateTime.Now;
                request.Employee.HireDate = DateTime.Now;
                request.Employee.UpdatedAt = DateTime.Now;
                request.Employee.Department = department;
                request.Employee.Position = position;


                _context.Employees.Add(request.Employee);

                bool result = await _context.SaveChangesAsync(cancellationToken) > 0;

                return !result ? Result<Unit>.Failure("Failed to create employee.") : Result<Unit>.Success(Unit.Value);
            }
        }
    }
}