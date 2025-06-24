using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public string Email
        {
            get
            {
                return this.User.Claims.FirstOrDefault(c => c.Type == "Email")!.Value;
            }
        }

        public string Id
        {
            get
            {
                return this.User.Claims.FirstOrDefault(c => c.Type == "Id")!.Value;
            }
        }

        public string UserLevel
        {
            get
            {
                return this.User.Claims.FirstOrDefault(c => c.Type == "UserLevel")!.Value;
            }
        }
    }
}
