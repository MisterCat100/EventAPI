using EventApi.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Model.EFCore;

public class Context : DbContext
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }
}
