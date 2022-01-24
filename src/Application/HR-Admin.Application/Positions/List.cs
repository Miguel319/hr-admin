using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using Admin_HR.Infrastructure.Persistence;
using HR_Admin.Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR_Admin.Application.Positions
{
    public class List
    {
        public class Query : IRequest<Result<List<Position>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<List<Position>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context) => _context = context;

            public async Task<Result<List<Position>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var positions = await _context.Positions.ToListAsync(cancellationToken);

                return Result<List<Position>>.Success(positions);
            }
        }
    }
}