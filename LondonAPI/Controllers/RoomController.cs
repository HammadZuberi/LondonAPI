using Microsoft.AspNetCore.Mvc;

namespace LondonAPI.Controllers
{
    [ApiController]
    [Route("/[Controller]")]
    public class RoomController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoom))]
        public IActionResult GetRoom()
        {
            ////absolute route
            //var response = new { href = Url.Link(nameof(GetRooms), null) };

            //return Ok(response);
            throw new NotImplementedException();
        }

        //[HttpGet(Name = nameof(GetRooms))]
        //public IActionResult GetRooms()
        //{
        //    //absolute route
        //    var response = new { href = Url.Link(nameof(GetRooms), null) };

        //    return Ok(response);
        //}
    }
}
