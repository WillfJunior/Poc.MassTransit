using Microsoft.EntityFrameworkCore;
using Poc.MassTransit.Message;

namespace Poc.MassTransit.worker.Infra
{
    public class LogDbContext : DbContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options) { }
        
        public DbSet<LogTeste> LogsPortal { get; set; }

        
    }
}
