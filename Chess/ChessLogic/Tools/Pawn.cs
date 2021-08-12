using System;
using System.Collections.Generic;
using static Chess.Table.Data;

namespace Chess.Tools
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
            bool isFirstMove = tools[position].isVirgin;
            if (isFirstMove) CheckPossibleMoves(chessMatrix[index[0]][index[1] + (direction * 2)], tools);

            CheckPossibleMoves(chessMatrix[index[0]][index[1] + direction], tools);
            CalcToolsToEat(CheckToolsToEat, tools);
        }

        private void CalcToolsToEat(Action<string, Dictionary<string, Tool>> check, Dictionary<string, Tool> tools)
        {
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

        public new void CheckPossibleMoves(string currentCell, Dictionary<string, Tool> tools)
        {
            bool isCellHasTool = tools.ContainsKey(currentCell);
            if (!isCellHasTool) possibleMoves.Add(currentCell);
        }

        public new void CheckThreatsMap(string currentCell, Dictionary<string, Tool> tools)
        {
            threatsMap.Add(currentCell);
        }

    }
}