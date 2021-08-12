using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess.Games;
using Chess.Tools;
using Chess.BL.Middleware;
using static Chess.Games.ApiResponse;

namespace Chess.Controllers
{
    [ApiController]
    [Route("api/game")]
    public class GameController : ControllerBase
    {
        [HttpGet] 
        [Route("get-game-tools/{gameId}")]
        [VerifyGameId]
        public Dictionary<string, ToolInfo> GetGameTools(long gameId)
        {
            return GamesManager.GetGame(gameId).GetGameToolsInfo();
        }


        [HttpGet]
        [Route("get-moves/{gameId}")]
        [VerifyGameId, VerifyQueryParams("pos")]
        public MovesResponse GetMoves(long gameId, string pos)
        {
            return GamesManager.GetGame(gameId).GetToolMoves(pos);
        }


        [HttpGet]
        [Route("move-tool/{gameId}")]
        [VerifyGameId, VerifyQueryParams("from", "to")]
        public MoveResponse MoveTool(long gameId, string from, string to)
        {
            return GamesManager.GetGame(gameId).MoveTool(from, to);
        }


        [HttpGet]
        [Route("game-state/{gameId}")]
        [VerifyGameId, VerifyQueryParams("colorTurn")]
        public GameStateResponse GameState(long gameId, bool colorTurn)
        {
            return GamesManager.GetGame(gameId).GetGameState(colorTurn);
        }


        [HttpGet]
        [Route("error/{message}")]
        public BadHttpRequestException Error(string message)
        {
            Response.StatusCode = 400;
            return new BadHttpRequestException(message, Response.StatusCode);
        }

        [HttpGet]
        [Route("test")]
        public string Test(string test)
        {
            return test;
        }
    }
}
