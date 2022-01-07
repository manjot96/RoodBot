using System;
using MongoDB.Driver;
using RoodBot.Data;
using RoodBot.Data.Models;

namespace RoodBot.Common
{
    public class ResourceService<T, C> : IResourceService<T> where T : Entity where C : IMongoDBContext
    {
        private C _context;
        protected IMongoCollection<T> _dbCollection;

        public ResourceService(C context)
        {
            _context = context;
            _dbCollection = _context.GetCollection<T>(typeof(T).Name);
        }

        public async Task<List<T>> GetAsync()
        {
            return await _dbCollection.Find(_ => true).ToListAsync();
        }

        public async Task<T?> GetAsync(string id)
        {
            return await _dbCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(T newBook)
        {
            await _dbCollection.InsertOneAsync(newBook);
        }

        public async Task UpdateAsync(string id, T updatedBook)
        {
            await _dbCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);
        }

        public async Task RemoveAsync(string id)
        {
            await _dbCollection.DeleteOneAsync(x => x.Id == id);
        }
    }   
}

