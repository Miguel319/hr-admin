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
        public async Task<ActionResult<Employee>> GetEmployee(Guid id)
            => HandleResult(await Mediator.Send(new Details.Query {Id = id}));

        [HttpPost]
        public async Task<ActionResult> CreateEmployee(Employee employee)
            => HandleResult(await Mediator.Send(new Create.Command {Employee = employee}));

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditEmployee(Guid id, Employee employee)
        {
            employee.Id = id;

            return HandleResult(await Mediator.Send(new Edit.Command {Employee = employee}));
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
            => HandleResult(await Mediator.Send(new Delete.Command {Id = id}));
        
    }
}