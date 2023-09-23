using logshared;
using Microsoft.EntityFrameworkCore;

namespace Poc.MassTransit.worker.Infra
{
    public class LogDbContext : DbContext
    {
        public LogDbContext(DbContextOptions<LogDbContext> options) : base(options) { }
        
        public DbSet<Logs> LogsPortal { get; set; }

        
    }
}
