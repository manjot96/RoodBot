using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using RoodBot.Data;
using RoodBot.Data.Models;

namespace RoodBot.WebApi.Services
{
    public class GameService
    {
        private readonly IMongoDBContext _context;
        protected IMongoCollection<Game> _dbCollection;
        public GameService(IMongoDBContext context)
        {
            _context = context;
            _dbCollection = _context.GetCollection<Game>(typeof(Game).Name);
        }

        public async Task<List<Game>> GetAsync()
        {
            return await _dbCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Game?> GetAsync(string id)
        {
            return await _dbCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Game newBook)
        {
            await _dbCollection.InsertOneAsync(newBook);
        }

        public async Task UpdateAsync(string id, Game updatedBook)
        {
            await _dbCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);
        }

        public async Task RemoveAsync(string id)
        {
            await _dbCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}

