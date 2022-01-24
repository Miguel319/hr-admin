using System.Collections.Generic;
using System.Threading.Tasks;
using Admin_HR.Domain.Entities;
using HR_Admin.Application.Positions;
using Microsoft.AspNetCore.Mvc;

namespace Admin_HR.API.Controllers
{
    public class PositionsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Position>>> GetPositions()
            => HandleResult(await Mediator.Send(new List.Query()));
    }
}