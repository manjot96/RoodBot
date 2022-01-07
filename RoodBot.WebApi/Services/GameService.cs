using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using RoodBot.Common;
using RoodBot.Data;
using RoodBot.Data.Models;

namespace RoodBot.WebApi.Services
{
    public class GameService : ResourceService<Game, IMongoDBContext>
    {
        public GameService(IMongoDBContext context) : base (context)
        {
        }
    }
}

