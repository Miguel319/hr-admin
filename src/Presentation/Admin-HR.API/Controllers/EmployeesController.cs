using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using HR_Admin.Application.Employees;
using Microsoft.AspNetCore.Mvc;

namespace Admin_HR.API.Controllers
{
    public class EmployeesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
            => HandleResult(await Mediator.Send(new List.Query()));
        
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Department>> GetEmployee(Guid id)
            => HandleResult(await Mediator.Send(new Details.Query {Id = id}));

    }
}