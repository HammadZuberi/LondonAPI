using LondonAPI.Models;

using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;

namespace LondonAPI.Controllers
{
    [ApiController]
    [Route("/[Controller]")]
    public class InfoController : ControllerBase
    {
        private readonly HotelInfo _hotelInfo;

        public InfoController(IOptions<HotelInfo> hotelInfowrapper)
        {
            _hotelInfo = hotelInfowrapper.Value;

        }

        [HttpGet(Name = nameof(GetInfo))]
        [ProducesResponseType(200)]
        public ActionResult<HotelInfo> GetInfo()
        {
            _hotelInfo.Href = Url.Link(nameof(GetInfo), null)!;

            
            return _hotelInfo;

        }
    }
}
