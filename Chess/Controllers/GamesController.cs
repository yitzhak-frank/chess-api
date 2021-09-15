using System;
using Microsoft.AspNetCore.Mvc;
using Chess.BL.Games;
using Chess.BL.Attributes;
using static Chess.ChessLogic.Table.Data;
using static Chess.BL.Games.ApiResponse;
using System.Collections.Generic;
using Chess.ChessLogic.Tools;

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
