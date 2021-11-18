using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Chess.BL.Games;

namespace Chess.BL.Attributes
{
    public class VerifyQueryParams : TypeFilterAttribute
    {
        public VerifyQueryParams(params string[] queryParams) : base(typeof(MyAttributeImpl))
        {
            Arguments = new object[] { queryParams };
        }

        private static void returnBadRequest(ActionExecutingContext context, string message) =>
            context.Result = new RedirectResult($"/api/error/bad-request/{message}");

        private class MyAttributeImpl : IActionFilter
        {
            private readonly string[] queryParams;

            public MyAttributeImpl(string[] queryParams) => this.queryParams = queryParams;

            public void OnActionExecuting(ActionExecutingContext context)
            {
                foreach (string query in queryParams)
                {
                    string queryValue = context.HttpContext.Request.Query[query].ToString();

                    if(queryValue == "") 
                    {
                        string message = $"Missing argument - '{query}' parameter is requierd";
                        returnBadRequest(context, message);
                        return;
                    } 
                    if(new Regex(@"^(to|from|toolPos)$").IsMatch(query) && !GamesManager.IsCellExist(queryValue))
                    {
                        string message = $"Incorrect argument - No such position as {queryValue}";
                        returnBadRequest(context, message);
                        return;
                    }
                    Boolean _;
                    if (query == "colorTurn" && !Boolean.TryParse(queryValue, out _))
                    {
                        string message = $"Incorrect argument - '{query}' parameter must have a boolean value, 'true' for white and 'false' for black";
                        returnBadRequest(context, message);
                        return;
                    }
                    if (query == "rank" && !new string[] { "Queen", "Rook", "Bishop", "Knight" }.Contains(queryValue, StringComparer.OrdinalIgnoreCase))
                    {
                        string message = $"Incorrect argument - '{query}' parameter must have one of the folowing values, 'Queen' | 'Rook' | 'Bishop' | 'Knight'";
                        returnBadRequest(context, message);
                        return;
                    }
                }
            }

            public void OnActionExecuted(ActionExecutedContext context) { }
        }
    }
}
