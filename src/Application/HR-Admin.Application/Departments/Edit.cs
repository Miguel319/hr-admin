using System;
using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using Admin_HR.Infrastructure.Persistence;
using AutoMapper;
using FluentValidation;
using HR_Admin.Application.Core;
using MediatR;

namespace HR_Admin.Application.Departments
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Department Department { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public class CommandValidator : AbstractValidator<Command>
            {
                public CommandValidator()
                    => RuleFor(x => x.Department).SetValidator(new DepartmentValidator());
            }
            
            public async Task<Result<Unit>?> Handle(Command request, CancellationToken cancellationToken)
            {
                var department = await _context.Departments.FindAsync(new object?[] { request.Department.Id }, cancellationToken: cancellationToken);

                if (department == null) return null;

                _mapper.Map(request.Department, department);

                department.UpdatedAt = DateTime.Now;

                var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                return !result ? Result<Unit>.Failure("Failed to update department.") : Result<Unit>.Success(Unit.Value);
            }
        }
    }
}