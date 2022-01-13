using System;
using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Infrastructure.Persistence;
using MediatR;

namespace HR_Admin.Application.Departments
{
    public class Delete 
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
                => _context = context;
            
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var department = await _context.Departments.FindAsync(request.Id);

                if (department == null) throw new Exception("Department not found.");

                _context.Remove(department);
                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}