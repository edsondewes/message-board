using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using NATS.Client;

namespace MessageBoard.Ranking.Api.HealthChecks
{
    public class NatsHealthCheck : IHealthCheck
    {
        private readonly IConnection _connection;

        public NatsHealthCheck(IConnection connection)
        {
            _connection = connection;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var result = _connection.State == ConnState.CONNECTED
                ? HealthCheckResult.Healthy()
                : HealthCheckResult.Unhealthy();

            return Task.FromResult(result);
        }
    }
}