using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using Admin_HR.Infrastructure.Persistence;
using AutoMapper;
using HR_Admin.Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HR_Admin.Application.Employees
{
    public class List
    {
        public class Query : IRequest<Result<List<EmployeeDto>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<List<EmployeeDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            } 

            public async Task<Result<List<EmployeeDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var employees = await _context.Employees.Include(x => x.Department).Include(x => x.Position)
                    .ToListAsync(  cancellationToken);

                var employeesToReturn = _mapper.Map<List<EmployeeDto>>(employees);
                
                return Result<List<EmployeeDto>>.Success(employeesToReturn);
            }
        }
    }
}