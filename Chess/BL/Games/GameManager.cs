using System;
using System.Collections.Generic;
using System.Threading;
using Chess.Tools;
using static Chess.Games.GamesManager;
using static Chess.Tools.ToolsFactory;
using static Chess.Table.Data;
using static Chess.Games.ApiResponse;
using Chess.Game.Guards;

namespace Chess.Game
{
    public class GameManager
    {
        public bool colorTurn;
        public long gameId { get; } = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        public Dictionary<string, Tool> tools { get; } = new () { };

        public GameManager(List<ToolInfo> toolsInfo, bool colorTurn)
        {
            InitGameTools(toolsInfo);
            this.colorTurn = colorTurn;
        }

        private void InitGameTools(List<ToolInfo> toolsInfo) => toolsInfo.ForEach(tool => tools.Add(tool.position, GetTool(tool)));

        public string IsMoveAllowed(string oldPos, string newPos)
        {
            Tool Tool = tools[oldPos];
            if (!tools.ContainsKey(oldPos)) return $"No tool found at {oldPos} position";
            if (tools.ContainsKey(newPos) && tools[newPos].color == Tool.color) return $"{(Tool.color ? "White" : "Black")} already have {tools[newPos].rank} in {newPos} position";
            if (Castling.IsCastling(oldPos, newPos, tools) && !Castling.GetCastlingMoves(tools[oldPos], tools).Contains(newPos)) return "Castling not allowed";
            if (!Tool.GetPossibleMoves(tools).Contains(newPos)) return $"{Tool.rank} at {oldPos} position can't go to {newPos} position";
            if (!Tool.GetTreathsFilteredMoves(tools).Contains(newPos)) return KingGuard.unallowedMoves[newPos];
            return "";
        }

        public Dictionary<string, ToolInfo> GetGameToolsInfo()
        {
            Dictionary<string, ToolInfo> toolsInfo = new() { };
            foreach (Tool Tool in tools.Values) toolsInfo.Add(Tool.position, Tool.GetToolInfo);
            return toolsInfo;
        }

        public MovesResponse GetToolMoves(string pos)
        {
            string message = $"No tool found at {pos} position";
            if (!tools.ContainsKey(pos)) return new MovesResponse(message, new List<string> { });

            List<string> moves = tools[pos].GetTreathsFilteredMoves(tools);
            message = $"{tools[pos].colorStr} {tools[pos].rank} at position {pos} have {moves.Count} possible moves";
            return new MovesResponse(message, moves);
        }

        public MoveResponse MoveTool(string oldPos, string newPos)
        {
            string moveState = IsMoveAllowed(oldPos, newPos);
            if (moveState != "") return new MoveResponse(false, colorTurn, moveState, GetGameToolsInfo());

            if (Castling.IsCastling(oldPos, newPos, tools)) moveState = Castle(oldPos, newPos);
            else
            {
                UpdateToolsOnMove(oldPos, newPos);
                moveState = $"{(tools[newPos].color ? "White" : "Black")} {tools[newPos].rank} from {oldPos} position, has been successfully moved to {newPos} position";
            }
            colorTurn = !colorTurn;
            return new MoveResponse(true, colorTurn, moveState, GetGameToolsInfo());
        }

        public void UpdateToolsOnMove(string oldPos, string newPos)
        {
            Tool Tool = tools[oldPos];

            if (tools.ContainsKey(newPos)) tools.Remove(newPos);
            tools.Add(newPos, Tool);

            Tool = tools[newPos];
            Tool.position = newPos;
            Tool.isVirgin = false;

            tools.Remove(oldPos);
        }

        private string Castle(string oldPos, string newPos)
        {
            UpdateToolsOnMove(oldPos, newPos);
            Dictionary<string, string> rookPositions = Castling.GetRookPosAndNewPos(oldPos, newPos, tools);
            UpdateToolsOnMove(rookPositions["oldPos"], rookPositions["newPos"]);

            Tool King = tools[newPos], Rook = tools[rookPositions["newPos"]];
            return $"Castling succeeded - {King.colorStr} King at {oldPos} position has been moved to {newPos} position and {Rook.colorStr} Rook at {rookPositions["oldPos"]} position has been moved to {Rook.position} position";
        }

        public GameStateResponse GetGameState()
        {
            string gameState = KingGuard.CheckGameState(new List<string> { }, colorTurn, tools);
            bool isChess = gameState.Contains("Chess"), isChessmate = gameState.Contains("Chessmate");
            return new GameStateResponse(gameState, KingGuard.kingThrets, isChess, isChessmate, colorTurn);
        }
    }
}