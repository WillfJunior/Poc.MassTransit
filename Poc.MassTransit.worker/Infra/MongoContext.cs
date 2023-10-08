using MongoDB.Driver;
using Poc.MassTransit.Message;

namespace Poc.MassTransit.worker.Infra
{
    public class MongoContext : IMongoContext
    {
        public MongoContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionStrings"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            LogsPortal = database.GetCollection<LogTeste>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        }
        public IMongoCollection<LogTeste> LogsPortal { get; }
    }
}
