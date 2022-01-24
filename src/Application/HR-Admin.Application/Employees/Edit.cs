using System;
using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using Admin_HR.Infrastructure.Persistence;
using AutoMapper;
using HR_Admin.Application.Core;
using MediatR;

namespace HR_Admin.Application.Employees
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Employee Employee { get; set; }
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

            
            public async Task<Result<Unit>?> Handle(Command request, CancellationToken cancellationToken)
            {
                var employee = await _context.Employees.FindAsync(new object?[] { request.Employee.Id }, cancellationToken);

                if (employee == null) return null;

                _mapper.Map(request.Employee, employee);

                employee.UpdatedAt = DateTime.Now;

                var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                return !result ? Result<Unit>.Failure("Failed to update employee.") : Result<Unit>.Success(Unit.Value);
            }
        }
    }
}