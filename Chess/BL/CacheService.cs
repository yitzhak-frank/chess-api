using System;
using Chess.BL.Game;
using Microsoft.Extensions.Caching.Memory;

namespace Chess.BL
{
    public class CacheService
    {
        static IMemoryCache cache;

        public static void SetIMemoryCache(IMemoryCache _cache)
        {
            cache = _cache;
        }

        public static void AddGameToCache(long gameId, GameManager game) => cache.Set(gameId, game, TimeSpan.FromDays(3));

        public static GameManager GetGameFromCache(long gameId)
        {
            cache.TryGetValue(gameId, out GameManager game);
            return game;
        }

        public static void RemoveGameFromCache(long gameId)
        {
            if(GetGameFromCache(gameId) != null) cache.Remove(gameId);
        }
            
    }
}
