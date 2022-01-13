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
            => await Mediator.Send(new List.Query());

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Department>> GetDepartment(Guid id)
            => await Mediator.Send(new Details.Query { Id = id});


        [HttpPost]
        public async Task<IActionResult> CreateDepartment(Department department)
        {
            return Ok(await Mediator.Send(new Create.Command {Department = department}));
        }
    }
}