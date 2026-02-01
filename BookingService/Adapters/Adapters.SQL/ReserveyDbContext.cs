using Adapters.SQL.Configurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Adapters.SQL
{
    public class ReserveyDbContext : DbContext
    {
        public ReserveyDbContext(DbContextOptions<ReserveyDbContext> options) : base(options) { }

        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GuestConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
        }
    }
}
