using Poc.MassTransit.Message;

namespace Poc.MassTransit.worker.Infra
{
    public class LogRepository : ILogRepository
    {
        private readonly IMongoContext _dbContext;

        public LogRepository(IMongoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddLog(LogTeste logs)
        {
            await _dbContext.LogsPortal.InsertOneAsync(logs);
            
        }
    }
}
