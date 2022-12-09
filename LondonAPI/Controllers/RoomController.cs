using LondonAPI.Models;
using LondonAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LondonAPI.Controllers
{
    [ApiController]
    [Route("/[Controller]")]
    public class RoomController : ControllerBase
    {

        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;

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

            var room = await _roomService.GetRoomAsyncId(roomId);

            if (room == null)
                return NotFound();

            return Ok(room);
        }

    }
}
