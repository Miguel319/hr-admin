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
        {
            return await Mediator.Send(new List.Query());
        }
    }
}