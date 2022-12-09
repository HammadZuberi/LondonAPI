using LondonAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LondonAPI.Controllers
{
    [ApiController]
    [Route("/[Controller]")]
    public class RoomController : ControllerBase
    {

        private readonly HotelApiDbContext _context;
        public RoomController(HotelApiDbContext context)
        {
            _context = context;

        }
        //[HttpGet(Name = nameof(GetRoom))]
        //public IActionResult GetRoom()
        //{
        //    ////absolute route
        //    //var response = new { href = Url.Link(nameof(GetRooms), null) };

        //    //return Ok(response);
        //    throw new NotImplementedException();
        //}

        [HttpGet(Name = nameof(GetRooms))]
        public ActionResult GetRooms()
        {
            //absolute route
            var response = new { href = Url.Link(nameof(GetRooms), null) };

            return Ok(response);
        }

        //Get  /rooms/{roomId}
        [HttpGet("{roomId}", Name = nameof(GetRoomByID))]
        public async Task<ActionResult<Room>> GetRoomByID(Guid roomId)
        {
            //absolute route
            //var response = new { href = Url.Link(nameof(GetRooms), null) };

            var room = await _context.Rooms.SingleOrDefaultAsync(x => x.Id == roomId);

            if (room == null)
            {
                return NotFound();
            }

            var response = new Room
            {
                Href = Url.Link(nameof(GetRooms), new { roomId = room.Id }),
                Name = room.Name,
                Rate = room.Rate / 100.0m

            };
            return Ok(response);
        }

    }
}
