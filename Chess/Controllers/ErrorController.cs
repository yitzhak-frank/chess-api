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
        public BadHttpRequestException BadRequest(string message)
        {
            Response.StatusCode = 400;
            return new BadHttpRequestException(message, Response.StatusCode);
        }
    }
}
