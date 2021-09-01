using System;
using Microsoft.AspNetCore.Mvc;
using Chess.Games;
using Chess.BL.Middleware;
using static Chess.Table.Data;
using static Chess.Games.ApiResponse;
using System.Collections.Generic;
using Chess.Tools;

namespace Chess.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GamesController : ControllerBase
    {
        [HttpGet]
        [Route("get-table")]
        public ActionResult<string[][]> GetTable()
        {
            return Ok(chessMatrix);
        }

        [HttpGet]
        [Route("get-tools")]
        public ActionResult<Dictionary<string, ToolInfo>> GetTools()
        {
            return Ok(GamesManager.GetInitalToolsInfo());
        }

        [HttpGet]
        [Route("start-game")]
        public ActionResult<NewGameResponse> StartGame()
        {
            return Ok(GamesManager.CreateNewGame());
        }

        [HttpPost]
        [Route("restart-game")]
        [VerifyGameTools, VerifyQueryParams("colorTurn")]
        public ActionResult<NewGameResponse> RestartGame(bool colorTurn)
        {
            return Ok(GamesManager.RestartGame(GamesManager.GetToolsFromReqBody(Request), colorTurn));
        }
    }
}
