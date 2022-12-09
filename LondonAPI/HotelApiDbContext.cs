using LondonAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LondonAPI
{
    public class HotelApiDbContext : DbContext
    {


        public HotelApiDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<RoomEntity> Rooms { get; set; }
    }
}
