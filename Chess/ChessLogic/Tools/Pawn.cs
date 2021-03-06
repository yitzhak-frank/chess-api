using System;
using System.Collections.Generic;
using static Chess.ChessLogic.Table.Data;

namespace Chess.ChessLogic.Tools
{
    public class Pawn : Tool
    {
        private int direction;

        public Pawn(ToolInfo ToolInfo) : base(ToolInfo)
        {
            direction = color ? 1 : -1;
        }

        public override List<string> GetPossibleMoves(Dictionary<string, Tool> tools)
        {
            SetIndex();
            possibleMoves.Clear();
            CalcPossibleMovesStraight(tools);
            CalcToolsToEat(CheckToolsToEat, tools);
            return possibleMoves;
        }

        public override List<string> GetThreatsMap(Dictionary<string, Tool> tools)
        {
            SetIndex();
            threatsMap.Clear();
            CalcToolsToEat(CheckThreatsMap, tools);
            return threatsMap;
        }

        private void CalcPossibleMovesStraight(Dictionary<string, Tool> tools)
        {
            bool isBlocked = CheckPossibleMoves(chessMatrix[index[0]][index[1] + direction], tools);
            bool isFirstMove = tools[position].isVirgin;
            if (isFirstMove && !isBlocked) CheckPossibleMoves(chessMatrix[index[0]][index[1] + (direction * 2)], tools);
        }

        private void CalcToolsToEat(Action<string, Dictionary<string, Tool>> check, Dictionary<string, Tool> tools)
        {
            if (index[1] == 0 || index[1] == 7) return;
            int length = chessMatrix.Length;
            if (index[0] + (direction * -1) >= 0 && index[0] + (direction * -1) < length)
                check(chessMatrix[index[0] + (direction * -1)][index[1] + direction], tools);
            if (index[0] + direction >= 0 && index[0] + direction < length)
                check(chessMatrix[index[0] + direction][index[1] + direction], tools);
        }

        private void CheckToolsToEat(string currentCell, Dictionary<string, Tool> tools)
        {
            bool isCellHasTool = tools.ContainsKey(currentCell);
            bool isOpponent = isCellHasTool && tools[currentCell].color != color;

            if (isOpponent) possibleMoves.Add(currentCell);
        }

        public new bool CheckPossibleMoves(string currentCell, Dictionary<string, Tool> tools)
        {
            bool isCellHasTool = tools.ContainsKey(currentCell);
            if (!isCellHasTool) possibleMoves.Add(currentCell);
            return isCellHasTool;
        }

        public new void CheckThreatsMap(string currentCell, Dictionary<string, Tool> tools)
        {
            threatsMap.Add(currentCell);
        }

    }
}