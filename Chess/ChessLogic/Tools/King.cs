using System;
using System.Collections.Generic;
using static Chess.ChessLogic.Table.Data;
using static Chess.ChessLogic.Table.Castling;

namespace Chess.ChessLogic.Tools
{
    public class King : Tool
    {
        public King(ToolInfo ToolInfo) : base(ToolInfo) { }

        public void CalcPossibleMoves(Action<string, Dictionary<string, Tool>> check, Dictionary<string, Tool> tools)
        {
            int length = chessMatrix.Length;

            SetIndex();

            if (index[1] - 1 >= 0)
                check(chessMatrix[index[0]][index[1] - 1], tools);
            if (index[0] - 1 >= 0)
                check(chessMatrix[index[0] - 1][index[1]], tools);
            if (index[0] + 1 < length)
                check(chessMatrix[index[0] + 1][index[1]], tools);
            if (index[1] + 1 < length)
                check(chessMatrix[index[0]][index[1] + 1], tools);
            if (index[0] - 1 >= 0 && index[1] + 1 < length)
                check(chessMatrix[index[0] - 1][index[1] + 1], tools);
            if (index[0] - 1 >= 0 && index[1] - 1 >= 0)
                check(chessMatrix[index[0] - 1][index[1] - 1], tools);
            if (index[0] + 1 < length && index[1] - 1 >= 0)
                check(chessMatrix[index[0] + 1][index[1] - 1], tools);
            if (index[0] + 1 < length && index[1] + 1 < length)
                check(chessMatrix[index[0] + 1][index[1] + 1], tools);
        }

        public override List<string> GetPossibleMoves(Dictionary<string, Tool> tools)
        {
            possibleMoves.Clear();
            CalcPossibleMoves(CheckPossibleMoves, tools);

            possibleMoves.AddRange(GetCastlingMoves(this, tools));
            return possibleMoves;
        }

        public new void CheckPossibleMoves(string currentCell, Dictionary<string, Tool> tools)
        {
            bool isCellHasTool = tools.ContainsKey(currentCell);
            bool isOpponent = isCellHasTool && tools[currentCell].color != color;

            if (!(isCellHasTool && !isOpponent)) possibleMoves.Add(currentCell);
        }

        public new void CheckThreatsMap(string currentCell, Dictionary<string, Tool> tools)
        {
            threatsMap.Add(currentCell);
        }
    }
}