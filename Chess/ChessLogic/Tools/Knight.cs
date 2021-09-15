using System;
using System.Collections.Generic;
using static Chess.ChessLogic.Table.Data;

namespace Chess.ChessLogic.Tools
{
    public class Knight : Tool
    {
        public Knight(ToolInfo ToolInfo) : base(ToolInfo) { }

        public override void CalcPossibleMoves(Func<string, Dictionary<string, Tool>, bool> check, Dictionary<string, Tool> tools)
        {
            int length = chessMatrix.Length;

            SetIndex();

            if (index[0] - 1 >= 0 && index[1] - 2 >= 0)
                check(chessMatrix[index[0] - 1][index[1] - 2], tools);
            if (index[0] - 2 >= 0 && index[1] - 1 >= 0)
                check(chessMatrix[index[0] - 2][index[1] - 1], tools);
            if (index[0] + 1 < length && index[1] - 2 >= 0)
                check(chessMatrix[index[0] + 1][index[1] - 2], tools);
            if (index[0] + 2 < length && index[1] - 1 >= 0)
                check(chessMatrix[index[0] + 2][index[1] - 1], tools);
            if (index[0] - 1 >= 0 && index[1] + 2 < length)
                check(chessMatrix[index[0] - 1][index[1] + 2], tools);
            if (index[0] - 2 >= 0 && index[1] + 1 < length)
                check(chessMatrix[index[0] - 2][index[1] + 1], tools);
            if (index[0] + 2 < length && index[1] + 1 < length)
                check(chessMatrix[index[0] + 2][index[1] + 1], tools);
            if (index[0] + 1 < length && index[1] + 2 < length)
                check(chessMatrix[index[0] + 1][index[1] + 2], tools);
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