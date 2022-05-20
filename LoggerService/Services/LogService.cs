using LoggerService.Configuration;
using LoggerService.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerService.Services
{
    public class LogService
    {
        private readonly IMongoCollection<Log> _logCollection;

        public LogService(
        IOptions<ProjectConfiguration> projectConfiguration)
        {
            var mongoClient = new MongoClient(
                projectConfiguration.Value.Mongo.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                projectConfiguration.Value.Mongo.DatabaseName);

            _logCollection = mongoDatabase.GetCollection<Log>(
                projectConfiguration.Value.Mongo.BooksCollectionName);
        }

        public async Task<List<Log>> GetAsync() =>
        await _logCollection.Find(_ => true).ToListAsync();

        public async Task<Log?> GetAsync(string id) =>
            await _logCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Log log) =>
            await _logCollection.InsertOneAsync(log);

        public async Task UpdateAsync(string id, Log log) =>
            await _logCollection.ReplaceOneAsync(x => x.Id == id, log);

        public async Task RemoveAsync(string id) =>
            await _logCollection.DeleteOneAsync(x => x.Id == id);
    }
}
