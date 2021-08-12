namespace Chess.Tools
{
    public static class ToolsFactory
    {
        public static Tool GetTool(ToolInfo ToolInfo)
        {
            switch (ToolInfo.rank)
            {
                case "King": return new King(ToolInfo);
                case "Queen": return new Queen(ToolInfo);
                case "Rook": return new Rook(ToolInfo);
                case "Bishop": return new Bishop(ToolInfo);
                case "Knight": return new Knight(ToolInfo);
                case "Pawn": return new Pawn(ToolInfo);
                default: return new Tool(ToolInfo);
            }
        }
    }
}