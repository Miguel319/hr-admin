using System;
using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using Admin_HR.Infrastructure.Persistence;
using HR_Admin.Application.Core;
using MediatR;

namespace HR_Admin.Application.Employees
{
    public class Details
    {
        public class Query : IRequest<Result<Employee>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result< Employee>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
                => _context = context;

            public async Task<Result<Employee>?> Handle(Query request, CancellationToken cancellationToken)
            {
                var employee = await _context.Employees.FindAsync(new object?[] { request.Id }, cancellationToken);

                if (employee == null) return null;
              
                return Result<Employee>.Success(employee);
            } 
        } 
    }
}