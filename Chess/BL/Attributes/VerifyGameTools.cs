using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Chess.Tools;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using static Chess.Table.Data;

namespace Chess.BL.Middleware
{
    public class VerifyGameTools : TypeFilterAttribute
    {
        public VerifyGameTools() : base(typeof(MyAttributeImpl)) { }

        public static string ReadBodyAsString(HttpRequest Request)
        {
            Request.EnableBuffering();
            string bodyStr = new StreamReader(Request.Body).ReadToEndAsync().Result;
            Request.Body.Position = 0;
            return bodyStr;
        }

        public static Dictionary<string, ToolInfo> GetToolsDictionary(string toolsStr)
        {
            Dictionary<string, ToolInfo> tools = new() { };
            return JsonConvert.DeserializeObject<Dictionary<string, ToolInfo>>(toolsStr) ?? tools;
        }

        private class MyAttributeImpl : IActionFilter
        {
            public void OnActionExecuting(ActionExecutingContext context)
            {
                HttpRequest Request = context.HttpContext.Request;
                Dictionary<string, ToolInfo> tools = GetToolsDictionary(ReadBodyAsString(Request));
                string message;

                if (tools.Count <= 0)
                {
                    message = "Incorrect content of request body, make sure everything in place as it should be";
                    context.Result = new RedirectResult($"/api/error/bad-request/{message}");
                    return;
                }

                string[] ranks = new string[6] { "King", "Queen", "Rook", "Bishop", "Knight", "Pawn" };
                Dictionary<string, int> kings = new() { { "Black", 0 }, { "White", 0 } };
                List<string> tableCells = new ();
                Array.ForEach(chessMatrix, (row) => Array.ForEach(row, (cell) => tableCells.Add(cell)));

                foreach (KeyValuePair<string, ToolInfo> tool in tools)
                {
                    if (!tableCells.Contains(tool.Key))
                    {
                        message = $"Incorrect content of request body, '{tool.Key}' is not a valid position";
                        context.Result = new RedirectResult($"/api/error/bad-request/{message}");
                        return;
                    }
                    if(tool.Key != tool.Value.position)
                    {
                        message = $"Incorrect content of request body, tool key at '{tool.Key}' position don't match his position field value '{tool.Value.position}'";
                        context.Result = new RedirectResult($"/api/error/bad-request/{message}");
                        return;
                    }
                    if(!ranks.Contains(tool.Value.rank))
                    {
                        message = $"Incorrect content of request body, tool rank '{tool.Value.rank}' at '{tool.Key}' position is not a valid rank, rank must be one of the followed values - {string.Join(',', ranks)}";
                        context.Result = new RedirectResult($"/api/error/bad-request/{message}");
                        return;
                    }

                    if(tool.Value.rank == "King") kings[tool.Value.color ? "White" : "Black"]++;
                }
                foreach (KeyValuePair<string, int> king in kings)
                {
                    if(king.Value > 1)
                    {
                        message = $"Incorrect content of request body, You have more then one {king.Key} king, you can have only one";
                        context.Result = new RedirectResult($"/api/error/bad-request/{message}");
                        return;
                    }
                    if(king.Value <= 0)
                    {
                        message = $"Incorrect content of request body, You don't have {king.Key} king";
                        context.Result = new RedirectResult($"/api/error/bad-request/{message}");
                        return;
                    }
                }
            }

            public void OnActionExecuted(ActionExecutedContext context) { }
        }
    }
}
