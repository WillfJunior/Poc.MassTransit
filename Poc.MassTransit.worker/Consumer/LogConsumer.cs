using MassTransit;
using Poc.MassTransit.Message;
using Poc.MassTransit.worker.Infra;

namespace Poc.MassTransit.worker.Consumer
{
    public class LogConsumer : IConsumer<LogTeste>
    {
        private readonly ILogRepository logRepository;

        public LogConsumer(ILogRepository logRepository)
        {
            this.logRepository = logRepository;
        }

        public async Task Consume(ConsumeContext<LogTeste> context)
        {
            await logRepository.AddLog(context.Message);
        }
    }
}
