using MassTransit;
using Poc.MassTransit.worker.Infra;

namespace Poc.MassTransit.worker.Consumer
{
    public class LogConsumer : IConsumer<logshared.Logs>
    {
        private readonly ILogRepository logRepository;

        public LogConsumer(ILogRepository logRepository)
        {
            this.logRepository = logRepository;
        }

        public async Task Consume(ConsumeContext<logshared.Logs> context)
        {
            await logRepository.AddLog(context.Message);
        }
    }
}
