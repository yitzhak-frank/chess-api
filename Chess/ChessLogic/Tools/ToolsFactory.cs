using System;

namespace Chess.ChessLogic.Tools
{
    public static class ToolsFactory
    {
        public static Tool GetTool(ToolInfo ToolInfo) =>
            (Tool)Activator.CreateInstance(Type.GetType("Chess.ChessLogic.Tools." + ToolInfo.rank), ToolInfo);
    }
}