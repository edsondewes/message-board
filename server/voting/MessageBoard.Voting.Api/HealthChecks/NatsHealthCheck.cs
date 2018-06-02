using System.Threading;
using System.Threading.Tasks;
using App.Metrics.Health;
using NATS.Client;

namespace MessageBoard.Voting.Api.HealthChecks
{
    public class NatsHealthCheck : HealthCheck
    {
        private readonly IConnection _connection;

        public NatsHealthCheck(IConnection connection)
            : base("NATS")
        {
            _connection = connection;
        }

        protected override ValueTask<HealthCheckResult> CheckAsync(CancellationToken cancellationToken = default)
        {
            var result = _connection.State == ConnState.CONNECTED
                ? HealthCheckResult.Healthy()
                : HealthCheckResult.Unhealthy();

            return new ValueTask<HealthCheckResult>(result);
        }
    }
}