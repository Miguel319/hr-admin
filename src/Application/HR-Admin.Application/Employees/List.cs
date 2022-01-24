using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using Admin_HR.Infrastructure.Persistence;
using HR_Admin.Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR_Admin.Application.Employees
{
    public class List
    {
        public class Query : IRequest<Result<List<Employee>>>
        {
            
        }

        public class Handler : IRequestHandler<Query, Result<List<Employee>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context) => _context = context;

            public async Task<Result<List<Employee>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var employees = await _context.Employees.ToListAsync(cancellationToken);

                return Result<List<Employee>>.Success(employees);
            }
        }
    }
}