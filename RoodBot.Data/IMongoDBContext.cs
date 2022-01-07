using System;
using MongoDB.Driver;

namespace RoodBot.Data
{
public interface IMongoDBContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}

