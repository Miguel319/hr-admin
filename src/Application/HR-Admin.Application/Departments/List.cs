using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using Admin_HR.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR_Admin.Application.Departments
{
    public class List
    {
        public class Query : IRequest<List<Department>>
        {
        }

        public class Handler : IRequestHandler<Query, List<Department>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context) => _context = context;


            public async Task<List<Department>> Handle(Query request, CancellationToken cancellationToken)
                => await _context.Departments.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}