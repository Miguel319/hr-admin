using System;
using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using Admin_HR.Infrastructure.Persistence;
using HR_Admin.Application.Core;
using MediatR;

namespace HR_Admin.Application.Departments
{
    public class Details
    {
        public class Query : IRequest<Result<Department>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result< Department>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
                => _context = context;

            public async Task<Result<Department>?> Handle(Query request, CancellationToken cancellationToken)
            {
              var department = await _context.Departments.FindAsync(new object?[] { request.Id }, cancellationToken);

              if (department == null) return null;
              
              return Result<Department>.Success(department);
            } 
        } 
    }
}