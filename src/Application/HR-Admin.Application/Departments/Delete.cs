using System;
using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Infrastructure.Persistence;
using HR_Admin.Application.Core;
using MediatR;

namespace HR_Admin.Application.Departments
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
                var department = await _context.Departments.FindAsync(request.Id);

                if (department == null) return null;

                _context.Remove(department);
                
                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete department.");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}