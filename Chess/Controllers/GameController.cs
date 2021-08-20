using Microsoft.AspNetCore.Mvc;
using Chess.Games;
using Chess.BL.Middleware;

namespace Chess.Controllers
{
    [ApiController]
    [Route("api/game")]
    [VerifyGameId]
    public class GameController : ControllerBase
    {
        [HttpGet] 
        [Route("get-game-tools/{gameId}")]
        public IActionResult GetGameTools(long gameId)
        {
            return Ok(GamesManager.GetGame(gameId).GetGameToolsInfo());
        }


        [HttpGet]
        [Route("get-moves/{gameId}")]
        [VerifyQueryParams("toolPos")]
        public IActionResult GetMoves(long gameId, string toolPos)
        {
            return Ok(GamesManager.GetGame(gameId).GetToolMoves(toolPos));
        }


        [HttpGet]
        [Route("move-tool/{gameId}")]
        [VerifyQueryParams("from", "to")]
        public IActionResult MoveTool(long gameId, string from, string to)
        {
            return Ok(GamesManager.GetGame(gameId).MoveTool(from, to));
        }


        [HttpGet]
        [Route("game-state/{gameId}")]
        [VerifyQueryParams("colorTurn")]
        public IActionResult GameState(long gameId, bool colorTurn)
        {
            return Ok(GamesManager.GetGame(gameId).GetGameState(colorTurn));
        }
    }
}
