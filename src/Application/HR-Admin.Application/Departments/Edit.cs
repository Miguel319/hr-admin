using System;
using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using Admin_HR.Infrastructure.Persistence;
using AutoMapper;
using MediatR;

namespace HR_Admin.Application.Departments
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Department Department { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var department = await _context.Departments.FindAsync(request.Department.Id);

                if (department == null)
                    throw new Exception("Department not Found.");

                _mapper.Map(request.Department, department);

                department.UpdatedAt = DateTime.Now;

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}