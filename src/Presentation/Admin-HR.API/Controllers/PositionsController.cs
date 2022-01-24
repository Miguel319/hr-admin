using System;
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


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<List<Position>>> GetPositionById(Guid id)
            => HandleResult(await Mediator.Send(new Details.Query() {Id = id}));

        [HttpPost]
        public async Task<ActionResult> CreatePosition(Position position)
            => HandleResult(await Mediator.Send(new Create.Command{Position = position}));

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdatePosition(Guid id, Position position)
        {
            position.Id = id;
            
            return HandleResult(await Mediator.Send(new Edit.Command {Position = position}));  
        } 
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePosition(Guid id)
            => HandleResult(await Mediator.Send(new Delete.Command {Id = id}));
    }
}