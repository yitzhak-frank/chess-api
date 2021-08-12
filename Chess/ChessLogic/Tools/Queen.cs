using System;
using System.Collections.Generic;
using static Chess.Table.Data;

namespace Chess.Tools
{
    public class Queen : Tool
    {
        public Queen(ToolInfo ToolInfo) : base(ToolInfo) { }

        public override void CalcPossibleMoves(Func<string, Dictionary<string, Tool>, bool> check, Dictionary<string, Tool> tools)
        {
            int length = chessMatrix.Length;

            SetIndex();

            for (int i = 1; index[0] - i >= 0; i++)
                if (check(chessMatrix[index[0] - i][index[1]], tools)) break;
            for (int i = 1; index[1] - i >= 0; i++)
                if (check(chessMatrix[index[0]][index[1] - i], tools)) break;
            for (int i = 1; i + index[0] < length; i++)
                if (check(chessMatrix[index[0] + i][index[1]], tools)) break;
            for (int i = 1; i + index[1] < length; i++)
                if (check(chessMatrix[index[0]][index[1] + i], tools)) break;
            for (int i = 1; (index[0] - i >= 0) && (index[1] - i >= 0); i++)
                if (check(chessMatrix[index[0] - i][index[1] - i], tools)) break;
            for (int i = 1; (index[0] - i >= 0) && (i + index[1] < length); i++)
                if (check(chessMatrix[index[0] - i][index[1] + i], tools)) break;
            for (int i = 1; (i + index[0] < length) && (index[1] - i >= 0); i++)
                if (check(chessMatrix[index[0] + i][index[1] - i], tools)) break;
            for (int i = 1; (i + index[0] < length) && (i + index[1] < length); i++)
                if (check(chessMatrix[index[0] + i][index[1] + i], tools)) break;
        }
    }
}