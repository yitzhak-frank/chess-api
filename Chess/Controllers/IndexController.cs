using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Controllers
{
    [Route("/")]
    public class IndexController : Controller
    {
        [HttpGet]
        [Route("/")]
        [Produces("text/html")]
        public ActionResult Get()
        {
            return Ok(System.IO.File.ReadAllText("wwwroot/index.html"));
        }
    }
}
