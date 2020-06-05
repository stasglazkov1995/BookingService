using System;
using System.Threading.Tasks;
using BookMe.BookingService.Application.Commands.EventCommands;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BookMe.BookingService.Application.Queries.EventQueries;
using BookMe.BookingService.Api.Models.Events;
using AutoMapper;

namespace BookMe.BookingService.Host.Areas.Events
{
    [Route("api/[area]")]
    public class EventsController : EventsControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EventsController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var query = new GetEventQuery(id);
            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<EventModel>(result));
        }

        [HttpGet("by-user")]
        public async Task<IActionResult> GetByUserAsync([FromQuery] Guid userId)
        {
            var query = new GetUserEventsQuery(userId);
            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<EventModel[]>(result));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateEventModel model)
        {
            var command = new CreateEventCommand(
                userId: model.UserId,
                name: model.Name,
                description: model.Description,
                lineOfBusiness: model.LineOfBusiness);

            var result = await _mediator.Send(command);

            return Ok(_mapper.Map<EventModel>(result));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateEventModel model)
        {
            var command = new UpdateEventCommand(
                id: model.Id,
                name: model.Name,
                description: model.Description,
                lineOfBusiness: model.LineOfBusiness);

            var result = await _mediator.Send(command);

            return Ok(_mapper.Map<EventModel>(result));
        }

        [HttpPatch("{id:guid}/activate")]
        public async Task<IActionResult> ActivateAsync([FromRoute] Guid id)
        {
            var command = new ActivateEventCommand(id);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPatch("{id:guid}/deactivate")]
        public async Task<IActionResult> DeactivateAsync([FromRoute] Guid id)
        {
            var command = new DeactivateEventCommand(id);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id)
        {
            var command = new DeleteEventCommand(id);
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}
