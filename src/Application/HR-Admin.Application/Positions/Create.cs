using System;
using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using Admin_HR.Infrastructure.Persistence;
using FluentValidation;
using HR_Admin.Application.Core;
using MediatR;

namespace HR_Admin.Application.Positions
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Position Position { get; set; }
        }

        public class PositionValidator : AbstractValidator<Command>
        {
            public PositionValidator()
                => RuleFor(x => x.Position).SetValidator(new Positions.PositionValidator());
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
                => _context = context;
            
            
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                request.Position.CreatedAt = DateTime.Now;
                request.Position.UpdatedAt = DateTime.Now;

                 _context.Positions.Add(request.Position);

                bool result = await _context.SaveChangesAsync(cancellationToken) > 0;

                if (!result) return Result<Unit>.Failure("Failed to create position.");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}