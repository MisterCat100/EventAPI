namespace EventApi.Model.Entities;

public class Event
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public DateTime Date { get; set; }
    public uint TicketCount { get; set; }
}
