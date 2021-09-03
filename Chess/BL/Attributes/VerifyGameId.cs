using System;
using Chess.BL.Games;
using Chess.BL.Game;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Chess.BL.Middleware
{
    public class VerifyGameId : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            long gameId = Convert.ToInt64(context.ActionArguments["gameId"]);
            GameManager Game = CacheService.GetGameFromCache(gameId);
            if (Game == null) 
            {
                string message = $"No game ID found match to {gameId}";
                context.Result = new RedirectResult($"/api/error/bad-request/{message}");
            }
            base.OnActionExecuting(context);
        }
    }
}