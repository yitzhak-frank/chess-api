using System;
using Chess.Games;
using Chess.Game;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Chess.BL.Middleware
{
    public class VerifyGameId : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            long gameId = Convert.ToInt64(context.ActionArguments["gameId"]);
            GameManager Game = GamesManager.games.Find(Game => Game.gameId == gameId);
            if (Game == null) 
            {
                string message = $"No game ID found match to {gameId}";
                context.Result = new RedirectResult($"/api/error/bad-request/{message}");
            }
            base.OnActionExecuting(context);
        }
    }
}