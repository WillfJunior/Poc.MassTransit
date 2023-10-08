using MongoDB.Driver;
using Poc.MassTransit.Message;

namespace Poc.MassTransit.worker.Infra
{
    public interface IMongoContext
    {
        IMongoCollection<LogTeste> LogsPortal { get; }
    }
}
