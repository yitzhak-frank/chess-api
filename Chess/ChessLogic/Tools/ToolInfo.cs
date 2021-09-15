namespace Chess.ChessLogic.Tools
{
    public class ToolInfo
    {
        public bool color { get; set; }
        public char tool { get; set; }
        public string position { get; set; }
        public bool isVirgin { get; set; }
        public string rank { get; set; }

        public ToolInfo(bool color, char tool, string position, bool isVirgin, string rank)
        {
            this.color = color;
            this.tool = tool;
            this.position = position;
            this.isVirgin = isVirgin;
            this.rank = rank;
        }
    }
}