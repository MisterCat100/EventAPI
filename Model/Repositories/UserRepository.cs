using EventApi.Model.EFCore;
using EventApi.Model.Entities;
using EventApi.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Model.Repositories;

public class UserRepository : IUserRepository
{
    private readonly Context _context;

    public UserRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<Ticket>> GetTickets(Guid UserId)
    {
        return await _context.Tickets.Where(t => t.UserId == UserId)
            .ToListAsync();
    }
}
