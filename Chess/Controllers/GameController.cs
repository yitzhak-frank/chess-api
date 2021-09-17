using Microsoft.AspNetCore.Mvc;
using Chess.BL.Games;
using Chess.BL.Attributes;
using static Chess.BL.Games.ApiResponse;

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

        [HttpGet]
        [Route("coronate/{gameId}")]
        [VerifyQueryParams("toolPos", "rank")]
        public ActionResult<CoronationResponse> Coronate(long gameId, string toolPos, string rank)
        {
            return Ok(GamesManager.GetGame(gameId).Coronate(toolPos, rank));
        }
    }
}
