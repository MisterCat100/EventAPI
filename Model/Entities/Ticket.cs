namespace EventApi.Model.Entities;

public class Ticket
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public Guid UserId { get; set; }
    public TicketStatus Status { get; set; } = TicketStatus.Free;
}

public enum TicketStatus
{
    Free = 0,
    Booked = 1,
    Bought = 2,
}