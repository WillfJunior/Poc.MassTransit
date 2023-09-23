using logshared;

namespace Poc.MassTransit.worker.Infra
{
    public class LogRepository : ILogRepository
    {
        private readonly LogDbContext _dbContext;

        public LogRepository(LogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddLog(Logs logs)
        {
            _dbContext.LogsPortal.Add(logs);
            await _dbContext.SaveChangesAsync();
        }
    }
}
