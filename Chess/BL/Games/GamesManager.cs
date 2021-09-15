using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Chess.ChessLogic.Tools;
using static Chess.BL.Games.ApiResponse;
using static Chess.ChessLogic.Table.Data;
using Chess.BL.Game;

namespace Chess.BL.Games
{
    public static class GamesManager
    {
        public static void RemoveGame(long gameId) => CacheService.RemoveGameFromCache(gameId);

        public static GameManager GetGame(long gameId) => CacheService.GetGameFromCache(gameId);

        public static Dictionary<string, ToolInfo> GetInitalToolsInfo()
        {
            StreamReader File = new ("BL/Tools.json");
            string toolsStr = File.ReadToEnd();
            return JsonConvert.DeserializeObject<Dictionary<string, ToolInfo>>(toolsStr);
        }

        public static Dictionary<string, ToolInfo> GetToolsFromReqBody(HttpRequest Req)
        {
            string body = new StreamReader(Req.Body).ReadToEndAsync().Result;
            Dictionary<string, ToolInfo> tools = JsonConvert.DeserializeObject<Dictionary<string, ToolInfo>>(body);
            return tools;
        }

        public static NewGameResponse CreateNewGame()
        {
            Dictionary<string, ToolInfo> tools = GetInitalToolsInfo();

            GameManager Game = new(tools.Values.ToList(), true);
            CacheService.AddGameToCache(Game.gameId, Game);

            return new NewGameResponse("Your game has been successfully initialized", Game.gameId, Game.colorTurn, Game.GetGameToolsInfo());
        }

        public static NewGameResponse RestartGame(Dictionary<string, ToolInfo> tools, bool colorTurn)
        {
            GameManager Game = new(tools.Values.ToList(), colorTurn);
            CacheService.AddGameToCache(Game.gameId, Game);

            return new NewGameResponse("Your game has been successfuly initialized", Game.gameId, Game.colorTurn, Game.GetGameToolsInfo());
        }

        public static bool IsCellExist(string pos)
        {
            foreach (string[] row in chessMatrix) foreach (string cell in row) if (cell == pos) return true;
            return false;
        }
    }
}