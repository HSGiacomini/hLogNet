using hLogNet.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace hLogNet.Services
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database = null;

        public MongoContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Process> Process
        {
            get
            {
                return _database.GetCollection<Process>("process");
            }
        }

        public IMongoCollection<Panel> Panel
        {
            get
            {
                return _database.GetCollection<Panel>("panel");
            }
        }
    }
}
