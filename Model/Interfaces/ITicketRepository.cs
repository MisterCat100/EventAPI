namespace EventApi.Model.Interfaces;

public interface ITicketRepository
{
    public Task BookTicket(Guid EventId);
    public Task BuyTicket(Guid TicketId);
    public Task CancelBooking(Guid BookId);
}
