using EventApi.Model.Entities;

namespace EventApi.Model.Interfaces;

public interface IUserRepository
{
    public Task<List<Ticket>> GetTickets(Guid UserId);
}
