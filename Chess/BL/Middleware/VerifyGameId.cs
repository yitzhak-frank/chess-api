using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess.Games;
using Chess.Game;
using System.Web.Http.Controllers;
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
                context.Result = new RedirectResult($"/api/game/error/{message}");
            }
            base.OnActionExecuting(context);
        }
    }
}