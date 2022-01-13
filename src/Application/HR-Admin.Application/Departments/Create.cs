using System;
using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using Admin_HR.Infrastructure.Persistence;
using MediatR;

namespace HR_Admin.Application.Departments
{
    public class Create
    {
        public class Command : IRequest
        {
            public Department Department { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
                => _context = context;
            
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                request.Department.CreatedAt = DateTime.Now;
                request.Department.UpdatedAt = DateTime.Now;
                
                 _context.Departments.Add(request.Department);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}