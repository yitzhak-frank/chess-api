using System.Collections.Generic;
using System.Linq;
using Chess.ChessLogic.Tools;
using static Chess.ChessLogic.Table.Data;

namespace Chess.ChessLogic.Table
{
    public static class Castling
    {
        private static List<string> castlingPath { get; set; } = new List<string> { };
        private static List<string> kingPath { get; set; } = new List<string> { };
        private static List<string> castlingMoves { get; set; } = new List<string> { };
        public static string unallowedCastlingMessage { get; set; } = "";

        public static List<string> GetCastlingMoves(Tool King, Dictionary<string, Tool> tools)
        {
            if (!King.isVirgin) return castlingMoves;

            List<Tool> rooks = GetVirginRooks(King, tools);
            castlingMoves.Clear();

            foreach (Tool Rook in rooks)
                if (IsCastlingPathClearFromTools(King, Rook, tools) && IsKingPathClearFromThreats(King, tools) && (rooks.Count > 0))
                    castlingMoves.Add(kingPath[1]);
            return castlingMoves;
        }

        private static List<Tool> GetVirginRooks(Tool King, Dictionary<string, Tool> tools) => tools.Values.ToList().FindAll(Tool => Tool.color == King.color && Tool is Rook && Tool.isVirgin);

        private static bool IsCastlingPathClearFromTools(Tool King, Tool Rook, Dictionary<string, Tool> tools)
        {
            SetCastlingPath(King, Rook);
            foreach (string position in castlingPath) if (tools.ContainsKey(position)) return false;
            return true;
        }

        public static void SetCastlingPath(Tool King, Tool Rook)
        {
            King.SetIndex();
            int[] kingIndex = King.index;
            castlingPath.Clear();

            while (chessMatrix[kingIndex[0] += Rook.position.CompareTo(King.position)][kingIndex[1]] != Rook.position)
                castlingPath.Add(chessMatrix[kingIndex[0]][kingIndex[1]]);
        }

        public static bool IsKingPathClearFromThreats(Tool King, Dictionary<string, Tool> tools)
        {
            SetKingPath();
            foreach (Tool tool in tools.Values)
            {
                if (tool.color == King.color) continue;
                if (tool.GetThreatsMap(tools).Intersect(kingPath.ToArray()).Any()) return false;
            }
            return true;
        }

        private static List<string> SetKingPath() => kingPath = castlingPath.Take(2).ToList();

        public static bool IsCastling(string oldPos, string newPos, Dictionary<string, Tool> tools)
        {
            Tool King = tools[oldPos];
            return King is King && King.isVirgin && "GC".Contains(newPos[0]); 
        }

        public static Dictionary<string, string> GetRookPosAndNewPos(string kingOldPos, string kingNewPos, Dictionary<string, Tool> tools)
        {
            Tool King = tools[kingNewPos];
            King.SetIndex();
            int[] kingIndex = King.index;
            string rookOldPos = tools.Values.ToList().Find(Tool => Tool is Rook && Tool.color == King.color && Tool.position.CompareTo(kingNewPos) != kingOldPos.CompareTo(kingNewPos)).position;
            string rookNewPos = chessMatrix[kingIndex[0] + kingOldPos.CompareTo(kingNewPos)][kingIndex[1]];
            return new Dictionary<string, string> { { "oldPos", rookOldPos }, { "newPos", rookNewPos } };
        }
    }
}
