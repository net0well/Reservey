using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Adapters.SQL
{
    public class ReserveyDbContext : DbContext
    {
        public ReserveyDbContext(DbContextOptions<ReserveyDbContext> options) : base(options) { }

        public virtual DbSet<Guest> Guests { get; set; }
    }
}
