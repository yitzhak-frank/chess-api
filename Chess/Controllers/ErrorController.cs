using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Controllers
{
    [ApiController]
    [Route("api/error")]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        [Route("bad-request/{message}")]
        public ActionResult<string> BadRequest(string message)
        {
            return BadRequest(message);
        }
    }
}
