using Poc.MassTransit.Message;

namespace Poc.MassTransit.worker.Infra
{
    public interface ILogRepository
    {
        Task AddLog(LogTeste logs);
    }
}