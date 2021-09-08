using System;

namespace Chess.Tools
{
    public static class ToolsFactory
    {
        public static Tool GetTool(ToolInfo ToolInfo) =>
            (Tool)Activator.CreateInstance(Type.GetType("Chess.Tools." + ToolInfo.rank), ToolInfo);
    }
}