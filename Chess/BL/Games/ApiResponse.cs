using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess.Game.Guards;
using Chess.Tools;

namespace Chess.Games
{
    public class ApiResponse
    {
        public class NewGameResponse
        {
            public string message { get; set; }
            public long gameId { get; set; }
            public Dictionary<string, ToolInfo> tools { get; set; }

            public NewGameResponse(string message, long gameId, Dictionary<string, ToolInfo> tools)
            {
                this.message = message;
                this.gameId = gameId;
                this.tools = tools;
            }
            
        }

        public class ToolsResponse
        {
            public string message { get; set; }
            public Dictionary<string, ToolInfo> tools { get; set; }

            public ToolsResponse(string message, Dictionary<string, ToolInfo> tools)
            {
                this.message = message;
                this.tools = tools;
            }
        }

        public class MovesResponse
        {
            public string message { get; set; }
            public List<string> moves { get; set; }
            public Dictionary<string, string> unallowedMoves { get; set; } = KingGuard.unallowedMoves;

            public MovesResponse(string message, List<string> moves)
            {
                this.message = message;
                this.moves = moves;
            }
        }

        public class MoveResponse
        {
            public bool success { get; set; }
            public string message { get; set; }
            public Dictionary<string, ToolInfo> tools { get; set; }

            public MoveResponse(bool success,string message, Dictionary<string, ToolInfo> tools)
            {
                this.message = message;
                this.tools = tools;
                this.success = success;
            }
        }
        
        public class GameStateResponse
        {
            public string gameState { get; set; }
            public string kingThreats { get; set; }
            public Dictionary<string, string> unallowedMoves { get; set; } = KingGuard.unallowedMoves;
            public GameStateResponse(string gameState, string kingThreats)
            {
                this.gameState = gameState;
                this.kingThreats = kingThreats;
            }
        }
    }
}
