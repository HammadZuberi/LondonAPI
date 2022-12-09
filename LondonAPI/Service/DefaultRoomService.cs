using LondonAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LondonAPI.Service
{
    public class DefaultRoomService : IRoomService
    {

        private readonly HotelApiDbContext _context;

        public DefaultRoomService(HotelApiDbContext context)
        {
            _context = context;
        }

        public Task<List<Room>> GetRoomAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Room> GetRoomAsyncId(Guid id)
        {
            var room = await _context.Rooms.SingleOrDefaultAsync(x => x.Id == id);

            if (room == null)
                return null;


            var response = new Room
            {
                Href = null,//Url.Link(nameof(GetRooms), new { roomId = room.Id }),
                Name = room.Name,
                Rate = room.Rate / 100.0m

            };
            return response;
        }
        //public async Task<List<Room>> GetRoomAsync()
        //{
        //    var room = await _context.Rooms.ToListAsync();

        //    if (room == null)
        //        return null;


        //    //var response = new Room
        //    //{
        //    //    Href = null,//Url.Link(nameof(GetRooms), new { roomId = room.Id }),
        //    //    Name = room.Name,
        //    //    Rate = room.Rate / 100.0m

        //    //};
        //    return room;
        //}
    }
}
