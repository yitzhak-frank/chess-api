using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess.ChessLogic.Table;
using Chess.ChessLogic.Tools;

namespace Chess.BL.Games
{
    public class ApiResponse
    {
        public class NewGameResponse
        {
            public string message { get; set; }
            public long gameId { get; set; }
            public bool colorTurn { get; set; }
            public Dictionary<string, ToolInfo> tools { get; set; }

            public NewGameResponse(string message, long gameId, bool colorTurn, Dictionary<string, ToolInfo> tools)
            {
                this.message = message;
                this.gameId = gameId;
                this.tools = tools;
                this.colorTurn = colorTurn;
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
            public bool colorTurn { get; set; }
            public string message { get; set; }
            public Dictionary<string, ToolInfo> tools { get; set; }

            public MoveResponse(bool success, bool colorTurn, string message, Dictionary<string, ToolInfo> tools)
            {
                this.message = message;
                this.tools = tools;
                this.success = success;
                this.colorTurn = colorTurn;
            }
        }
        
        public class GameStateResponse
        {
            public bool isChess { get; set; }
            public bool isChessmate { get; set; }
            public bool colorThreatend { get; set; }
            public string gameState { get; set; }
            public string kingThreats { get; set; }
            public Dictionary<string, string> unallowedMoves { get; set; } = KingGuard.unallowedMoves;

            public GameStateResponse(string gameState, string kingThreats, bool isChess, bool isChessmate, bool colorThreatend)
            {
                this.gameState = gameState;
                this.kingThreats = kingThreats;
                this.isChess = isChess;
                this.isChessmate = isChessmate;
                this.colorThreatend = colorThreatend;
            }
        }
    }
}
