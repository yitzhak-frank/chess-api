using System;
using System.Collections.Generic;
using static Chess.Table.Data;
using static Chess.Game.Guards.KingGuard;

namespace Chess.Tools
{
    public class Tool
    {
        public bool color { get; set; }
        public string colorStr { get; set; }
        public char tool { get; set; }
        public string position { get; set; }
        public bool isVirgin { get; set; }
        public string rank { get; set; }
        public int[] index { get; set; }
        public List<string> threatsMap { get; set; } = new List<string> { };
        public List<string> possibleMoves { get; set; } = new List<string> { };

        public Tool(ToolInfo ToolInfo)
        {
            color = ToolInfo.color;
            tool = ToolInfo.tool;
            position = ToolInfo.position;
            isVirgin = ToolInfo.isVirgin;
            rank = ToolInfo.rank;
            colorStr = color ? "White" : "Black";
        }

        public ToolInfo GetToolInfo => new (color, tool, position, isVirgin, rank);

        public List<string> GetTreathsFilteredMoves(Dictionary<string, Tool> tools) => FilterThreatenedMoves(this, color, GetPossibleMoves(tools), tools);

        public virtual List<string> GetPossibleMoves(Dictionary<string, Tool> tools)
        {
            possibleMoves.Clear();
            CalcPossibleMoves(CheckPossibleMoves, tools);
            return possibleMoves;
        }

        public virtual List<string> GetThreatsMap(Dictionary<string, Tool> tools)
        {
            threatsMap.Clear();
            CalcPossibleMoves(CheckThreatsMap, tools);
            return threatsMap;
        }

        public virtual void CalcPossibleMoves(Func<string, Dictionary<string, Tool>, bool> check, Dictionary<string, Tool> tools) { }

        public bool CheckPossibleMoves(string currentCell, Dictionary<string, Tool> tools)
        {
            bool isCellHasTool = tools.ContainsKey(currentCell);
            bool isOpponent = isCellHasTool && tools[currentCell].color != color;

            if (isCellHasTool && !isOpponent) return true;

            possibleMoves.Add(currentCell);

            if (isCellHasTool) return true;
            else return false;
        }

        public bool CheckThreatsMap(string currentCell, Dictionary<string, Tool> tools)
        {
            bool isCellHasTool = tools.ContainsKey(currentCell);

            threatsMap.Add(currentCell);

            if (!isCellHasTool) return false;
            else return true;
        }

        public void SetIndex()
        {
            for (int i = 0; i < chessMatrix.Length; i++)
            {
                for (int x = 0; x < chessMatrix[i].Length; x++)
                {
                    if (chessMatrix[i][x] == position)
                    {
                        index = new int[2] { i, x };
                        return;
                    }
                }
            }
        }
    }
}
