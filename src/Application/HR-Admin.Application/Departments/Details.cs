using System;
using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using Admin_HR.Infrastructure.Persistence;
using MediatR;

namespace HR_Admin.Application.Departments
{
    public class Details
    {
        public class Query : IRequest<Department>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Department>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
                => _context = context;


            public async Task<Department> Handle(Query request, CancellationToken cancellationToken)
                => await _context.Departments.FindAsync(request.Id);
        }
    }
}