using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            StreamReader File = new StreamReader("BL/Tools.json");
            string toolsStr = File.ReadToEnd();
            return JsonConvert.DeserializeObject<Dictionary<string, ToolInfo>>(toolsStr);
        }

        public static NewGameResponse CreateNewGame()
        {
            Dictionary<string, ToolInfo> tools = GetInitalToolsInfo();

            GameManager Game = new(tools.Values.ToList());
            games.Add(Game);

            return new NewGameResponse("Your game has been successfully initialized", Game.gameId, Game.GetGameToolsInfo());
        }

        public static async Task<NewGameResponse> RestartGameAsync(Stream reqBody)
        {
            using StreamReader body = new(reqBody, Encoding.UTF8);
            string toolsStr = await body.ReadToEndAsync();
            Dictionary<string, ToolInfo> tools = JsonConvert.DeserializeObject<Dictionary<string, ToolInfo>>(toolsStr);

            GameManager Game = new(tools.Values.ToList());
            games.Add(Game);

            return new NewGameResponse("You game successfuly initialized", Game.gameId, Game.GetGameToolsInfo());
        }

        public static bool IsCellExist(string pos)
        {
            foreach (string[] row in chessMatrix) foreach (string cell in row) if (cell == pos) return true;
            return false;
        }
    }
}