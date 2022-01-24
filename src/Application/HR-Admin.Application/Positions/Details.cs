using System;
using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using Admin_HR.Infrastructure.Persistence;
using HR_Admin.Application.Core;
using MediatR;

namespace HR_Admin.Application.Positions
{
    public class Details
    {
        public class Query : IRequest<Result<Position>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Position>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
                => _context = context;
            
            public async Task<Result<Position>> Handle(Query request, CancellationToken cancellationToken)
            {
                var position = await _context.Positions.FindAsync(new object?[] {request.Id}, cancellationToken);

                return Result<Position>.Success(position);
            }
        }
    }
}