 using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using HR_Admin.Application.Departments;
using Microsoft.AspNetCore.Mvc;

namespace Admin_HR.API.Controllers
{
    public class DepartmentsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetDepartments()
            => HandleResult(await Mediator.Send(new List.Query()));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Department>> GetDepartment(Guid id)
        => HandleResult(await Mediator.Send(new Details.Query { Id = id}));

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(Department department)
        => HandleResult(await Mediator.Send(new Create.Command {Department = department}));

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditDepartment(Guid id, Department department)
        {
            department.Id = id;

            return HandleResult(await Mediator.Send(new Edit.Command {Department = department}));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteDepartment(Guid id)
            => HandleResult(await Mediator.Send(new Delete.Command {Id = id}));
    }
}