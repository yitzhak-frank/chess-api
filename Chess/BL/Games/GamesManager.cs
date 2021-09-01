using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Chess.Tools;
using Chess.Game;
using static Chess.Games.ApiResponse;
using static Chess.Table.Data;

namespace Chess.Games
{
    public static class GamesManager
    {
        public static List<GameManager> games = new List<GameManager> { };

        public static void RemoveGame(long gameId) => games.Remove(games.Find(Game => Game.gameId == gameId));

        public static GameManager GetGame(long gameId) => games.Find(Game => Game.gameId == gameId);

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
            games.Add(Game);

            return new NewGameResponse("Your game has been successfully initialized", Game.gameId, Game.colorTurn, Game.GetGameToolsInfo());
        }

        public static NewGameResponse RestartGame(Dictionary<string, ToolInfo> tools, bool colorTurn)
        {
            GameManager Game = new(tools.Values.ToList(), colorTurn);
            games.Add(Game);

            return new NewGameResponse("Your game has been successfuly initialized", Game.gameId, Game.colorTurn, Game.GetGameToolsInfo());
        }

        public static bool IsCellExist(string pos)
        {
            foreach (string[] row in chessMatrix) foreach (string cell in row) if (cell == pos) return true;
            return false;
        }
    }
}