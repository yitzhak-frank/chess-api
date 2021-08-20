using Microsoft.AspNetCore.Mvc;
using Chess.Games;
using Chess.BL.Middleware;
using static Chess.Table.Data;

namespace Chess.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GamesController : ControllerBase
    {
        [HttpGet]
        [Route("get-table")]
        public IActionResult GetTable()
        {
            return Ok(chessMatrix);
        }

        [HttpGet]
        [Route("get-tools")]
        public IActionResult GetTools()
        {
            return Ok(GamesManager.GetInitalToolsInfo());
        }

        [HttpGet]
        [Route("start-game")]
        public IActionResult StartGame()
        {
            return Ok(GamesManager.CreateNewGame());
        }

        [HttpPost]
        [Route("restart-game")]
        [VerifyGameTools]
        public IActionResult RestartGame()
        {
            return Ok(GamesManager.RestartGame(GamesManager.GetToolsFromReqBody(Request)));
        }
    }
}
