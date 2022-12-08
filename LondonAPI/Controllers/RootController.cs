using Microsoft.AspNetCore.Mvc;

namespace LondonAPI.Controllers
{
    [ApiController]
    [Route("/")]
    [ApiVersion("1.0")]
    public class RootController : Controller
    {
        [HttpGet(Name = nameof(GetRoot))]

        public IActionResult GetRoot()
        {

            //absolute route
            var response = new
            {
                href = Url.Link(nameof(GetRoot), null),
                rooms = new
                {
                    href = Url.Link(nameof(RoomController.GetRoom), null)
                }
            };

            return Ok(response);
        }
    }
}
