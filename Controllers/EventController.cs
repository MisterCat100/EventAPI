using EventApi.Model.Entities;
using EventApi.Model.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventApi.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class EventController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IUserRepository _userRepository;

        public EventController(
            ITicketRepository ticketRepository,
            IUserRepository userRepository)
        {
            _ticketRepository = ticketRepository;
            _userRepository = userRepository;
        }

        [HttpGet("GetTickets")]
        public async Task< ApiResponse< List<Ticket> > > GetTickets(Guid UserId)
        {
            ApiResponse<List<Ticket>> response = new()
            {
                IsSucess = true,
                Message = null,
                Data = await _userRepository.GetTickets(UserId),
            };

            return response;
        }

        [HttpPut("BookTicket")]
        public async Task BookTicket(Guid EventId)
        {
            await _ticketRepository.BookTicket(EventId);
        }

        [HttpPut("BuyTicket")]
        public async Task BuyTicket(Guid TicketId)
        {
            await _ticketRepository.BuyTicket(TicketId);
        }

        [HttpPut("CancelBooking")]
        public async Task CancelBooking(Guid BookId)
        {
            await _ticketRepository.CancelBooking(BookId);
        }
    }
}
