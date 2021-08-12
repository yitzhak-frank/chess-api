using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Chess.Tools;
using Newtonsoft.Json.Linq;
using Chess.Game;
using Chess.Games;
using static Chess.Games.ApiResponse;
using static Chess.Table.Data;

namespace Chess.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        [HttpGet, Route("get-table")]
        public string[][] GetTable()
        {
            return chessMatrix;
        }

        [HttpGet, Route("get-tools")]
        public Dictionary<string, ToolInfo> GetTools()
        {
            return GamesManager.GetInitalToolsInfo();
        }

        [HttpGet, Route("start-game")]
        public NewGameResponse StartGame()
        {
            return GamesManager.CreateNewGame();
        }

        [HttpPost, Route("restart-game")]
        public async Task<NewGameResponse> RestartGame()
        {
            return await GamesManager.RestartGameAsync(Request.Body);
        }
    }
}
