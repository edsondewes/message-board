using System.Threading;
using System.Threading.Tasks;
using App.Metrics.Health;
using StackExchange.Redis;

namespace MessageBoard.Voting.Api.HealthChecks
{
    public class RedisHealthCheck : HealthCheck
    {
        private readonly IConnectionMultiplexer _connection;

        public RedisHealthCheck(IConnectionMultiplexer connection)
            : base("Redis")
        {
            _connection = connection;
        }

        protected override async ValueTask<HealthCheckResult> CheckAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _connection.GetDatabase().PingAsync();
                return HealthCheckResult.Healthy();
            }
            catch
            {
                return HealthCheckResult.Unhealthy();
            }
        }
    }
}