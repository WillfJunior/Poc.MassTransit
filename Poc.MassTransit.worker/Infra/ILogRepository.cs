using logshared;

namespace Poc.MassTransit.worker.Infra
{
    public interface ILogRepository
    {
        Task AddLog(Logs logs);
    }
}