using EventApi.Model.EFCore;
using EventApi.Model.Entities;
using EventApi.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Model.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly Context _context;

    public TicketRepository(Context context)
    {
        _context = context;
    }

    public async Task BookTicket(Guid EventId)
    {
        Event? dbEvent = await _context.Events.FirstOrDefaultAsync(e => e.Id == EventId);

        if (dbEvent != null)
        {
            if (dbEvent.TicketCount <= 0)
                return;

            dbEvent.TicketCount--;
            Ticket ticket = await _context.Tickets.FirstAsync(t => t.Status == TicketStatus.Free);
             
            ticket.Status = TicketStatus.Booked;

            await _context.SaveChangesAsync();
        }
    }

    public async Task BuyTicket(Guid TicketId)
    {
        Ticket? ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == TicketId);

        if (ticket == null || ticket.Status != TicketStatus.Booked)
            return;
        
        ticket.Status = TicketStatus.Bought;

        await _context.SaveChangesAsync();
    }

    public async Task CancelBooking(Guid BookId)
    {
        Ticket? ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == BookId);

        if (ticket == null || ticket.Status != TicketStatus.Booked)
            return;

        ticket.Status = TicketStatus.Free;

        await _context.SaveChangesAsync();
    }
}
