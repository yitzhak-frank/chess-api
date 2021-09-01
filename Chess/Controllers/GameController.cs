using Microsoft.AspNetCore.Mvc;
using Chess.Games;
using Chess.BL.Middleware;
using static Chess.Games.ApiResponse;

namespace Chess.Controllers
{
    [ApiController]
    [Route("api/game")]
    [VerifyGameId]
    public class GameController : ControllerBase
    {
        [HttpGet] 
        [Route("get-game-tools/{gameId}")]
        public ActionResult<ToolsResponse> GetGameTools(long gameId)
        {
            return Ok(GamesManager.GetGame(gameId).GetGameToolsInfo());
        }


        [HttpGet]
        [Route("get-moves/{gameId}")]
        [VerifyQueryParams("toolPos")]
        public ActionResult<MovesResponse> GetMoves(long gameId, string toolPos)
        {
            return Ok(GamesManager.GetGame(gameId).GetToolMoves(toolPos));
        }


        [HttpGet]
        [Route("move-tool/{gameId}")]
        [VerifyQueryParams("from", "to")]
        public ActionResult<MoveResponse> MoveTool(long gameId, string from, string to)
        {
            return Ok(GamesManager.GetGame(gameId).MoveTool(from, to));
        }


        [HttpGet]
        [Route("game-state/{gameId}")]
        public ActionResult<GameStateResponse> GameState(long gameId)
        {
            return Ok(GamesManager.GetGame(gameId).GetGameState());
        }
    }
}
