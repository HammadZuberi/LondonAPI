using AutoMapper;
using LondonAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LondonAPI.Service
{
    public class DefaultRoomService : IRoomService
    {

        private readonly HotelApiDbContext _context;

        // inject auto mapper into the service
        private readonly IMapper _mapper;

        public DefaultRoomService(HotelApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Room> GetRoomAsyncId(Guid id)
        {
            var room = await _context.Rooms.SingleOrDefaultAsync(x => x.Id == id);

            if (room == null)
                return null;

            return _mapper.Map<Room>(room);

            //var response = new Room
            //{
            //    Href = null,//Url.Link(nameof(GetRooms), new { roomId = room.Id }),
            //    Name = room.Name,
            //    Rate = room.Rate / 100.0m

            //};
            //return response;
            //Implemente auto mapper

        }


        public async Task<List<Room>> GetRoomAsync()
        {
            var room = await _context.Rooms.ToListAsync();

            if (room == null)
                return null;


            return _mapper.Map<List<Room>>(room);
        }
    }
}
