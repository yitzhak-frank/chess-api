using System.Collections.Generic;
using System.Linq;
using Chess.ChessLogic.Tools;

namespace Chess.ChessLogic.Table
{
    public static class KingGuard
    {
        public static string kingThrets { get; set; } = "";
        public static Dictionary<string, string> unallowedMoves { get; set; } = new() { };

        public static List<string> FilterThreatenedMoves(Tool SelectedTool, bool colorTurn, List<string> possibleMoves, Dictionary<string, Tool> tools)
        {
            string kingPos = GetKingPosition(colorTurn, tools);
            Tool DeletedInstance = tools[SelectedTool.position];

            tools.Remove(SelectedTool.position);
            unallowedMoves.Clear();

            if (SelectedTool is King) FilterKingPossibleMoves(SelectedTool, possibleMoves, colorTurn, tools);
            else
            {
                foreach (Tool tool in tools.Values.ToList())
                {
                    if (tool.color == colorTurn) continue;
                    if (tool.GetThreatsMap(tools).Contains(kingPos))
                        FilterThreatenedMove(DeletedInstance, tool, kingPos, possibleMoves, tools);
                }
            }
            tools.Add(SelectedTool.position, DeletedInstance);
            return possibleMoves;
        }

        private static string GetKingPosition(bool colorTurn, Dictionary<string, Tool> tools)
        {
            foreach (KeyValuePair<string, Tool> tool in tools)
                if (tool.Value is King && tool.Value.color == colorTurn) return tool.Key;
            return "";
        }

        private static void FilterKingPossibleMoves(Tool King, List<string> possibleMoves, bool colorTurn, Dictionary<string, Tool> tools)
        {
            foreach (Tool Tool in tools.Values.ToList())
                if (Tool.color != colorTurn) FilterThreatenedMove(King, Tool, "", possibleMoves, tools);
        }

        private static void FilterThreatenedMove(Tool Defender, Tool Attacker, string king, List<string> possibleMoves, Dictionary<string, Tool> tools)
        {
#nullable enable
            Tool? ToolExisted;
            string? kingPos;
#nullable disable
            foreach (string move in possibleMoves.ToList())
            {
                // if selected tool is king do the chess check on his possible moves position
                kingPos = king == "" ? move : king;
                // if there is another tool in this position save him
                ToolExisted = tools.ContainsKey(move) ? tools[move] : null;
                // if Attacker will be killed by moving the tool allow it
                if (ToolExisted != null && ToolExisted.position == Attacker.position) continue;

                if (ToolExisted != null) tools.Remove(move);

                tools.Add(move, Defender);
                if (Attacker.GetThreatsMap(tools).Contains(kingPos))
                {
                    SaveThreateMessage(Attacker, Defender, move, kingPos);
                    possibleMoves.Remove(move);
                }
                else if (king == "" && Attacker.GetThreatsMap(tools).Contains(move)) SaveThreateMessage(Attacker, move);
                tools.Remove(move);
                if (ToolExisted != null) tools.Add(move, ToolExisted);
            }
        }

        private static void SaveThreateMessage(Tool Tool, string move)
        {
            string message = $"{Tool.colorStr} {Tool.rank} at {Tool.position} position threatens the king move to {move}";
            unallowedMoves.Add(move, message);
        }

        private static void SaveThreateMessage(Tool Attacker, Tool Defender, string move, string kingPos)
        {
            string message = $"Moving the {Defender.colorStr} {Defender.rank} at {Defender.position} position to {move} position will expose the {Defender.colorStr} King at {kingPos} position to the {Attacker.colorStr} {Attacker.rank} at {Attacker.position} position";
            unallowedMoves.Add(move, message);
        }

        public static string CheckGameState(List<string> ThreatsMap, bool colorTurn, Dictionary<string, Tool> tools)
        {
            kingThrets = "";
            bool isChess = CheckIfChess(ThreatsMap, colorTurn, tools);
            string kingPos = GetKingPosition(colorTurn, tools);
            List<string> kingPossibleMoves = tools[kingPos].GetPossibleMoves(tools);

            unallowedMoves.Clear();
            FilterKingPossibleMoves(tools[kingPos], kingPossibleMoves, colorTurn, tools);

            if (!isChess) return CheckStalemate(colorTurn, tools);
            return CheckChessmate(colorTurn, kingPossibleMoves, tools);
        }

        private static bool CheckIfChess(List<string> threatsMap, bool colorTurn, Dictionary<string, Tool> tools)
        {
            string kingPos = GetKingPosition(colorTurn, tools);
            bool isChess = false;
            threatsMap.Clear();

            foreach (Tool Tool in tools.Values)
            {
                if (colorTurn == Tool.color) continue;
                if (Tool.GetThreatsMap(tools).Contains(kingPos)) 
                {
                    kingThrets = $"{Tool.colorStr} {Tool.rank} at position {Tool.position} threatens the king";
                    isChess = true;
                    break;
                }
                threatsMap = threatsMap.Union(Tool.GetThreatsMap(tools)).ToList();
            }
            return isChess;
        }

        private static string CheckChessmate(bool colorTurn, List<string> possibleMoves, Dictionary<string, Tool> tools) =>
            (possibleMoves.Count > 0 || CheckIfOneOfTheToolsCanMove(colorTurn, tools)) ? "Chess ⚠" : $"Game Over Chessmate!";
        

        private static string CheckStalemate(bool colorTurn, Dictionary<string, Tool> tools) => 
            CheckIfOneOfTheToolsCanMove(colorTurn, tools) ? "Active game" : "Game Over Stalemate";

        private static bool CheckIfOneOfTheToolsCanMove(bool colorTurn, Dictionary<string, Tool> tools)
        {
            foreach (Tool tool in tools.Values.ToList())
            {
                if (tool.color != colorTurn) continue;

                List<string> toolPossibleMoves = tool.GetPossibleMoves(tools);
                FilterThreatenedMoves(tool, colorTurn, toolPossibleMoves, tools);

                if (toolPossibleMoves.Count > 0) return true;
            }
            return false;
        }
    }
}