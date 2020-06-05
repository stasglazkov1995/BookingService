using System;
using System.Threading.Tasks;
using AutoMapper;
using BookMe.BookingService.Api.Models.Bookings;
using BookMe.BookingService.Application.Commands.BookingCommands;
using BookMe.BookingService.Application.Queries.BookingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookMe.BookingService.Host.Areas.Bookings
{
    [Route("api/[area]")]
    public class BookingsController : BookingsControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BookingsController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var query = new GetBookingQuery(id);            

            var result = await _mediator.Send(query);
            return Ok(_mapper.Map<BookingModel>(result));
        }

        [HttpGet("user/{userId:guid}")]
        public async Task<IActionResult> GetByUserAsync([FromRoute] Guid userId)
        {
            var query = new GetUserBookingsQuery
            {
                // TODO: fill query
            };

            var result = await _mediator.Send(query);
            return Ok(_mapper.Map<BookingModel>(result));
        }

        [HttpGet("event/{eventId:guid}")]
        public async Task<IActionResult> GetByEventAsync([FromRoute] Guid eventId)
        {
            var query = new GetEventBookingsQuery
            {
                // TODO: fill query
            };

            var result = await _mediator.Send(query);
            return Ok(_mapper.Map<BookingModel>(result));
        }

        [HttpPost]
        public async Task<IActionResult> PlaceBookingAsync([FromBody] PlaceBookingModel model)
        {
            var command = new PlaceBookingCommand(
                model.EventId,
                model.CustomerId,
                model.BookingDate);
            

            var result = await _mediator.Send(command);
            return Ok(_mapper.Map<BookingModel>(result));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBookingAsync([FromBody] UpdateBookingCommand model)
        {
            var command = new UpdateBookingCommand
            {
                // TODO: fill command
            };

            var result = await _mediator.Send(command);
            return Ok(_mapper.Map<BookingModel>(result));
        }

        [HttpPost("approve")]
        public async Task<IActionResult> ApproveBookingAsync([FromBody] ApproveBookingModel model)
        {
            var command = new ApproveBookingCommand(model.BookingId);

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("reject")]
        public async Task<IActionResult> RejectBookingAsync([FromBody] RejectBookingCommand model)
        {
            var command = new RejectBookingCommand
            {
                // TODO: fill command
            };

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("cancel")]
        public async Task<IActionResult> CancelBookingAsync([FromBody] CancelBookingCommand model)
        {
            var command = new CancelBookingCommand
            {
                // TODO: fill command
            };

            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
