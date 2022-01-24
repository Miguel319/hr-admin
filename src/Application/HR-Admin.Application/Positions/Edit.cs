using System;
using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using Admin_HR.Infrastructure.Persistence;
using AutoMapper;
using FluentValidation;
using HR_Admin.Application.Core;
using MediatR;

namespace HR_Admin.Application.Positions
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Position Position { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public class CommandValidator : AbstractValidator<Command>
            {
                public CommandValidator()
                    => RuleFor(x => x.Position).SetValidator(new PositionValidator());
            }


            public async Task<Result<Unit>?> Handle(Command request, CancellationToken cancellationToken)
            {
                var position =
                    await _context.Positions.FindAsync(new object?[] {request.Position.Id}, cancellationToken);

                if (position == null) return null;

                _mapper.Map(request.Position, position);

                position.UpdatedAt = DateTime.Now;

                var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                return !result ? Result<Unit>.Failure("Failed to update position.") : Result<Unit>.Success(Unit.Value);
            }
        }
    }
}