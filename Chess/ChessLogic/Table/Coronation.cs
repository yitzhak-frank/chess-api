using System;
using Chess.ChessLogic.Tools;

namespace Chess.ChessLogic.Table
{
    public static class Coronation
    {
        public static string IsCoronation(ToolInfo tool)
        {
            if (tool.rank != "Pawn")
                return $"{tool.rank} can not be coronated only pawns can";
            if (tool.color && !tool.position.Contains("8"))
                return $"White pawns can be coronated only in the 8th row";
            if (!tool.color && !tool.position.Contains("1"))
                return $"Black pawns can be coronated only in the 1th row";
            return "";
        }

    }
}
