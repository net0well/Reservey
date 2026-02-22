using Domain.Entities;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace Adapters.SQL.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private ReserveyDbContext _context;
        public GuestRepository(ReserveyDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(Guest guest)
        {
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
            return guest.Id;
        }

        public async Task<Guest?> Get(int id)
        {
            return await _context.Guests.FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
