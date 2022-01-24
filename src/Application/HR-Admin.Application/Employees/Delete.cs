using System;
using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Infrastructure.Persistence;
using HR_Admin.Application.Core;
using MediatR;

namespace HR_Admin.Application.Employees
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
                => _context = context;
            
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var employee = await _context.Employees.FindAsync(request.Id);

                if (employee == null) return null;

                _context.Remove(employee);
                
                var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                return !result ? Result<Unit>.Failure("Failed to delete employee.") : Result<Unit>.Success(Unit.Value);
            }
        }
    }
}